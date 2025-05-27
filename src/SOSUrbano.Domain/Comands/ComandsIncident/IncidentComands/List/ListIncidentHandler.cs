using MediatR;
using SOSUrbano.Domain.Interfaces.Repositories.IncidentRepository;

namespace SOSUrbano.Domain.Comands.ComandsIncident.IncidentComands.List
{
    internal class ListIncidentHandler
        (IRepositoryIncident repositoryIncident) :
        IRequestHandler<ListIncidentRequest, ListIncidentResponse>
    {
        public async Task<ListIncidentResponse> Handle
            (ListIncidentRequest request, CancellationToken cancellationToken)
        {
            var incidents = await repositoryIncident.GetAllAsync();

            return new ListIncidentResponse(incidents);
        }
    }
}
