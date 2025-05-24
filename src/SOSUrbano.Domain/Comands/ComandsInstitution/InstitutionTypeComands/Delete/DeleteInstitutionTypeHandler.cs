using MediatR;
using SOSUrbano.Domain.Interfaces.Repositories.InstitutionRepository;

namespace SOSUrbano.Domain.Comands.ComandsInstitution.InstitutionTypeComands.Delete
{
    internal class DeleteInstitutionTypeHandler
        (IRepositoryInstitutionType repositoryInstitutionType) :
        IRequestHandler<DeleteInstitutionTypeRequest, DeleteInstitutionTypeResponse>
    {
        public async Task<DeleteInstitutionTypeResponse> Handle
            (DeleteInstitutionTypeRequest request, CancellationToken cancellationToken)
        {
            var institutionType = await repositoryInstitutionType.GetByIdAsync(request.Id);

            if (institutionType is null)
                throw new Exception("Tipo não encontrado.");

            repositoryInstitutionType.Delete(institutionType.Id);

            await repositoryInstitutionType.CommitAsync();

            return new DeleteInstitutionTypeResponse("Tipo excluído com sucesso");
        }
    }
}
