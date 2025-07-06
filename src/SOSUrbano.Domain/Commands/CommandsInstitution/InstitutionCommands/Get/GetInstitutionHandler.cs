using MediatR;
using SOSUrbano.Domain.Commands.CommandsInstitution.InstitutionCommands.Dto;
using SOSUrbano.Domain.Commands.CommandsInstitution.InstitutionEmailCommands.Dto;
using SOSUrbano.Domain.Commands.CommandsInstitution.InstitutionPhoneCommands.Dto;
using SOSUrbano.Domain.Commands.CommandsInstitution.InstitutionStatusCommands.Dto;
using SOSUrbano.Domain.Commands.CommandsInstitution.InstitutionTypeCommands.Dto;
using SOSUrbano.Domain.Interfaces.Repositories.InstitutionRepository;
using ValidationException = FluentValidation.ValidationException;

namespace SOSUrbano.Domain.Commands.CommandsInstitution.InstitutionCommands.Get
{
    internal class GetInstitutionHandler
        (IRepositoryInstitution repositoryInstitution) :
        IRequestHandler<GetInstitutionRequest, GetInstitutionResponse>
    {
        public async Task<GetInstitutionResponse> Handle
            (GetInstitutionRequest request, CancellationToken cancellationToken)
        {
            var validator = new GetInstitutionValidation();

            var validationResult = validator.Validate(request);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var institution = await repositoryInstitution.GetInstitutionByIdAsync(request.Id);


            if (institution is null)
                throw new Exception("Instituição não encontrada.");
            
            var response = new DtoInstitutionResponse(
                institution.Id,
                institution.Name,
                institution.Cnpj,
                institution.UrlSite,
                institution.Description,
                institution.Address,
                new DtoInstitutionStatusResponse(institution.InstitutionStatusId, institution.InstitutionStatus.Name),
                new DtoInstitutionTypeResponse(institution.InstitutionTypeId, institution.InstitutionType.Name),
                institution.InstitutionEmails.Select(email =>
                new DtoInstitutionEmailResponse(email.Id, email.EmailAddress)).ToList(),
                institution.InstitutionPhones.Select(phone =>
                new DtoInstitutionPhoneResponse(phone.Id, phone.Number)).ToList());
            
            return new GetInstitutionResponse(response);
        }
    }
}
