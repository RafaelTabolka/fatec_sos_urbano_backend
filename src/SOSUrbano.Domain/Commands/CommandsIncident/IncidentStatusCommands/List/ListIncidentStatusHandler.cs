using MediatR;
using SOSUrbano.Domain.Interfaces.Repositories.IncidentRepository;

namespace SOSUrbano.Domain.Commands.CommandsIncident.IncidentStatusCommands.List
{
    internal class ListIncidentStatusHandler
        (IRepositoryIncidentStatus repositoryIncidentStatus) :
        IRequestHandler<ListIncidentStatusRequest, ListIncidentStatusResponse>
    {
        public async Task<ListIncidentStatusResponse> Handle
            (ListIncidentStatusRequest request, CancellationToken cancellationToken)
        {
            var incidentStatuses = await repositoryIncidentStatus.GetAllAsync();

            return new ListIncidentStatusResponse(incidentStatuses);
        }
    }
}
