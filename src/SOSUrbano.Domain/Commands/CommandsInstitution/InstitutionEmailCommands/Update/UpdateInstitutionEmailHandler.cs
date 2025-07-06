using MediatR;
using SOSUrbano.Domain.Interfaces.Repositories.InstitutionRepository;
using ValidationException = FluentValidation.ValidationException;

namespace SOSUrbano.Domain.Commands.CommandsInstitution.InstitutionEmailCommands.Update
{
    internal class UpdateInstitutionEmailHandler
        (IRepositoryInstitutionEmail repositoryInstitutionEmail) :
        IRequestHandler<UpdateInstitutionEmailRequest, UpdateInstitutionEmailResponse>
    {
        public async Task<UpdateInstitutionEmailResponse> Handle
            (UpdateInstitutionEmailRequest request, CancellationToken cancellationToken)
        {
            var validator = new UpdateInstitutionEmailValidation();

            var validationResult = validator.Validate(request);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var institutionEmail = await repositoryInstitutionEmail.
                GetByIdAsync(request.Id);

            if (institutionEmail is null)
                throw new Exception("Email não encontrado");

            institutionEmail.EmailAddress = request.EmailAddress;

            repositoryInstitutionEmail.Update(institutionEmail);

            await repositoryInstitutionEmail.CommitAsync();

            return new UpdateInstitutionEmailResponse("Atualizado com sucesso");
        }
    }
}
