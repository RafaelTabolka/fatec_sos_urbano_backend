using MediatR;
using SOSUrbano.Domain.Interfaces.Repositories.IncidentRepository;

namespace SOSUrbano.Domain.Comands.ComandsIncident.IncidentComands.Delete
{
    internal class DeleteIncidentHandler
        (IRepositoryIncident repositoryIncident) :
        IRequestHandler<DeleteIncidentRequest, DeleteIncidentResponse>
    {
        public async Task<DeleteIncidentResponse> Handle
            (DeleteIncidentRequest request, CancellationToken cancellationToken)
        {
            var incident = await repositoryIncident.GetByIdAsync(request.Id);

            if (incident is null)
                throw new Exception("Denúncia não encontrada.");

            repositoryIncident.Delete(incident.Id);

            await repositoryIncident.CommitAsync();

            return new DeleteIncidentResponse("Denúncia deletada com sucesso.");
        }
    }
}
