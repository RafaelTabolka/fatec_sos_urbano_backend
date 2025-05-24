using MediatR;

namespace SOSUrbano.Domain.Comands.ComandsIncident.IncidentStatusComands.Update
{
    public class UpdateIncidentStatusRequest :
        IRequest<UpdateIncidentStatusResponse>
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
