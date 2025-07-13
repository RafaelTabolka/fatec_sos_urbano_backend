using MediatR;
using SOSUrbano.Domain.Entities.InstitutionEntity;
using SOSUrbano.Domain.Interfaces.Repositories.InstitutionRepository;
using ValidationException = FluentValidation.ValidationException;

namespace SOSUrbano.Domain.Commands.CommandsInstitution.InstitutionCommands.Create
{
    internal class CreateInstitutionHandler(
        IRepositoryInstitution repositoryInstitution,
        IRepositoryInstitutionStatus repositoryInstitutionStatus,
        IRepositoryInstitutionType repositoryInstitutionType) :
        IRequestHandler<CreateInstitutionRequest, CreateInstitutionResponse>
    {
        public async Task<CreateInstitutionResponse> Handle
            (CreateInstitutionRequest request, CancellationToken cancellationToken)
        {
            var validator = new CreateInstitutionValidation();

            var validationResult = validator.Validate(request);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var institutionStatus = await repositoryInstitutionStatus
                .GetStatusByNameAsync(request.InstitutionStatusName);

            var institutionType = await repositoryInstitutionType
                .GetTypeByNameAsync(request.InstitutionTypeName);

            var institution = new Institution(
                request.Name,
                request.Cnpj,
                request.UrlSite,
                request.Description,
                request.Address,
                institutionStatus.Id,
                institutionType.Id);

            institution.InstitutionEmails = request.InstitutionEmails
                .Select(email => new InstitutionEmail
                (email.EmailAddress, institution.Id)).ToList();

            institution.InstitutionPhones = request.InstitutionPhones
                .Select(phone => new InstitutionPhone
                (phone.Number, institution.Id)).ToList();

            await repositoryInstitution.AddAsync(institution);
            await repositoryInstitution.CommitAsync();

            return new CreateInstitutionResponse
                (institution.Id, "Instituição criada com sucesso");

        }
    }
}
