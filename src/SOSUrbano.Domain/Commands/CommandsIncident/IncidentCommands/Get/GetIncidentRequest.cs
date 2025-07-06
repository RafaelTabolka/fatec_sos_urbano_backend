using MediatR;

namespace SOSUrbano.Domain.Commands.CommandsIncident.IncidentCommands.Get
{
    public class GetIncidentRequest(Guid id) :
        IRequest<GetIncidentResponse>
    {
        public Guid Id { get; set; } = id;
    }
}
