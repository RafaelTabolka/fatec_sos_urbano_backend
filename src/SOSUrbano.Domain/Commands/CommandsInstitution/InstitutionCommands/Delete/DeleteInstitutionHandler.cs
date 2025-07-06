using MediatR;
using SOSUrbano.Domain.Interfaces.Repositories.InstitutionRepository;
using ValidationException = FluentValidation.ValidationException;

namespace SOSUrbano.Domain.Commands.CommandsInstitution.InstitutionCommands.Delete
{
    internal class DeleteInstitutionHandler
        (IRepositoryInstitution repositoryInstitution) :
        IRequestHandler<DeleteInstitutionRequest, DeleteInstitutionResponse>
    {
        public async Task<DeleteInstitutionResponse> Handle
            (DeleteInstitutionRequest request, CancellationToken cancellationToken)
        {
            var validator = new DeleteInstitutionValidation();

            var validationResult = validator.Validate(request);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var institution = await repositoryInstitution.GetByIdAsync(request.Id);

            if (institution is null)
                throw new Exception("Instituição não encontrada");

            repositoryInstitution.Delete(institution.Id);
            await repositoryInstitution.CommitAsync();

            return new DeleteInstitutionResponse("Instituição deletada com sucesso.");

        }
    }
}
