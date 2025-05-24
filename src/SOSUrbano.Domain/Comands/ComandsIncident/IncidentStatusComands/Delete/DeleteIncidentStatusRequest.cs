using MediatR;

namespace SOSUrbano.Domain.Comands.ComandsIncident.IncidentStatusComands.Delete
{
    public class DeleteIncidentStatusRequest(Guid id) :
        IRequest<DeleteIncidentStatusResponse>
    {
        public Guid Id { get; set; } = id;
    }
}
