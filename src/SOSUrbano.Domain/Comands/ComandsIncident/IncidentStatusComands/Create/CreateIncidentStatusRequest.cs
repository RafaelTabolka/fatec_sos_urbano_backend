using MediatR;

namespace SOSUrbano.Domain.Comands.ComandsIncident.IncidentStatusComands.Create
{
    public class CreateIncidentStatusRequest :
        IRequest<CreateIncidentStatusResponse>
    {
        public string Name { get; set; } = string.Empty;
    }
}
