using MediatR;

namespace SOSUrbano.Domain.Comands.ComandsIncident.IncidentComands.Delete
{
    public class DeleteIncidentRequest(Guid id) :
        IRequest<DeleteIncidentResponse>
    {
        public Guid Id { get; set; } = id;
    }
}
