using MediatR;
using SOSUrbano.Domain.Interfaces.Repositories.InstitutionRepository;

namespace SOSUrbano.Domain.Comands.ComandsInstitution.InstitutionStatusComands.Delete
{
    internal class DeleteInstitutionStatusHandler
        (IRepositoryInstitutionStatus repositoryInstitutionStatus) :
        IRequestHandler<DeleteInstitutionStatusRequest, DeleteInstitutionStatusResponse>
    {
        public async Task<DeleteInstitutionStatusResponse> Handle
            (DeleteInstitutionStatusRequest request, CancellationToken cancellationToken)
        {
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
