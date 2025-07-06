using MediatR;
using SOSUrbano.Domain.Interfaces.Repositories.InstitutionRepository;
using ValidationException = FluentValidation.ValidationException;

namespace SOSUrbano.Domain.Commands.CommandsInstitution.InstitutionStatusCommands.Delete
{
    internal class DeleteInstitutionStatusHandler
        (IRepositoryInstitutionStatus repositoryInstitutionStatus) :
        IRequestHandler<DeleteInstitutionStatusRequest, DeleteInstitutionStatusResponse>
    {
        public async Task<DeleteInstitutionStatusResponse> Handle
            (DeleteInstitutionStatusRequest request, CancellationToken cancellationToken)
        {
            var validator = new DeleteInstitutionStatusValidation();

            var validationResult = validator.Validate(request);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var institutionStatus = await repositoryInstitutionStatus.
                GetByIdAsync(request.Id);

            if (institutionStatus is null)
                throw new Exception("Status não encontrado.");

            repositoryInstitutionStatus.Delete(institutionStatus.Id);

            await repositoryInstitutionStatus.CommitAsync();

            return new DeleteInstitutionStatusResponse("Status excluído com sucesso");
        }
    }
}
