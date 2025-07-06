using MediatR;

namespace SOSUrbano.Domain.Commands.CommandsIncident.IncidentCommands.Delete
{
    public class DeleteIncidentRequest(Guid id) :
        IRequest<DeleteIncidentResponse>
    {
        public Guid Id { get; set; } = id;
    }
}
