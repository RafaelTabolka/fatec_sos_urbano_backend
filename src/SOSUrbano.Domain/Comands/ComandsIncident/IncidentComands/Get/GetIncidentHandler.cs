using MediatR;
using SOSUrbano.Domain.Interfaces.Repositories.IncidentRepository;

namespace SOSUrbano.Domain.Comands.ComandsIncident.IncidentComands.Get
{
    internal class GetIncidentHandler
        (IRepositoryIncident repositoryIncident) :
        IRequestHandler<GetIncidentRequest, GetIncidentResponse>
    {
        public async Task<GetIncidentResponse> Handle
            (GetIncidentRequest request, CancellationToken cancellationToken)
        {
            var incident = await repositoryIncident.GetByIdAsync(request.Id);

            if (incident is null)
                throw new Exception("Denúncia não encontrada.");

            return new GetIncidentResponse(incident); 
        }
    }
}
