using MediatR;
using SOSUrbano.Domain.Interfaces.Repositories.InstitutionRepository;
using ValidationException = FluentValidation.ValidationException;

namespace SOSUrbano.Domain.Comands.ComandsInstitution.InstitutionTypeComands.Delete
{
    internal class DeleteInstitutionTypeHandler
        (IRepositoryInstitutionType repositoryInstitutionType) :
        IRequestHandler<DeleteInstitutionTypeRequest, DeleteInstitutionTypeResponse>
    {
        public async Task<DeleteInstitutionTypeResponse> Handle
            (DeleteInstitutionTypeRequest request, CancellationToken cancellationToken)
        {
            var validator = new DeleteInstitutionTypeValidation();

            var validationResult = validator.Validate(request);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var institutionType = await repositoryInstitutionType.GetByIdAsync(request.Id);

            if (institutionType is null)
                throw new Exception("Tipo não encontrado.");

            repositoryInstitutionType.Delete(institutionType.Id);

            await repositoryInstitutionType.CommitAsync();

            return new DeleteInstitutionTypeResponse("Tipo excluído com sucesso");
        }
    }
}
