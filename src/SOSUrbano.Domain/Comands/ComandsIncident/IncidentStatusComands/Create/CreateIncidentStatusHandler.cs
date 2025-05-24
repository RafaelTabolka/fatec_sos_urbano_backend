using MediatR;
using SOSUrbano.Domain.Entities.IncidentEntity;
using SOSUrbano.Domain.Interfaces.Repositories.IncidentRepository;

namespace SOSUrbano.Domain.Comands.ComandsIncident.IncidentStatusComands.Create
{
    internal class CreateIncidentStatusHandler
        (IRepositoryIncidentStatus repositoryIncidentStatus) :
        IRequestHandler<CreateIncidentStatusRequest, CreateIncidentStatusResponse>
    {
        public async Task<CreateIncidentStatusResponse> Handle
            (CreateIncidentStatusRequest request, CancellationToken cancellationToken)
        {
            var incidentStatus = new IncidentStatus(request.Name);

            await repositoryIncidentStatus.AddAsync(incidentStatus);
            await repositoryIncidentStatus.CommitAsync();

            return new CreateIncidentStatusResponse(incidentStatus.Id, "Status da denúncia criado com sucesso");
        }
    }
}
