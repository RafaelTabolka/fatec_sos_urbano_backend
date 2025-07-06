using MediatR;

namespace SOSUrbano.Domain.Commands.CommandsIncident.IncidentStatusCommands.Create
{
    public class CreateIncidentStatusRequest :
        IRequest<CreateIncidentStatusResponse>
    {
        public string Name { get; set; } = string.Empty;
    }
}
