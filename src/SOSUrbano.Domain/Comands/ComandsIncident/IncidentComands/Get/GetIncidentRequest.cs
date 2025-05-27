using MediatR;

namespace SOSUrbano.Domain.Comands.ComandsIncident.IncidentComands.Get
{
    public class GetIncidentRequest(Guid id) :
        IRequest<GetIncidentResponse>
    {
        public Guid Id { get; set; } = id;
    }
}
