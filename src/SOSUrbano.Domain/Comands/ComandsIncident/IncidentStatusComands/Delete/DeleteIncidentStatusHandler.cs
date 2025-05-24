using MediatR;
using SOSUrbano.Domain.Interfaces.Repositories.IncidentRepository;

namespace SOSUrbano.Domain.Comands.ComandsIncident.IncidentStatusComands.Delete
{
    internal class DeleteIncidentStatusHandler
        (IRepositoryIncidentStatus repositoryIncidentStatus) :
        IRequestHandler<DeleteIncidentStatusRequest, DeleteIncidentStatusResponse>
    {
        public async Task<DeleteIncidentStatusResponse> Handle
            (DeleteIncidentStatusRequest request, CancellationToken cancellationToken)
        {
            var incidentStatus = await repositoryIncidentStatus.
                GetByIdAsync(request.Id);

            if (incidentStatus is null)
                throw new Exception("Usuário não encontrado");

            repositoryIncidentStatus.Delete(incidentStatus.Id);

            await repositoryIncidentStatus.CommitAsync();

            return new DeleteIncidentStatusResponse("Status excluído com sucesso");
        }
    }
}
