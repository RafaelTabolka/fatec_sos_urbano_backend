using MediatR;

namespace SOSUrbano.Domain.Commands.CommandsIncident.IncidentStatusCommands.Delete
{
    public class DeleteIncidentStatusRequest(Guid id) :
        IRequest<DeleteIncidentStatusResponse>
    {
        public Guid Id { get; set; } = id;
    }
}
