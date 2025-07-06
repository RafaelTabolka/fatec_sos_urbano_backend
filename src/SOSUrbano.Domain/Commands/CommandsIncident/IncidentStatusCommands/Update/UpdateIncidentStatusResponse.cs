using SOSUrbano.Domain.Entities.IncidentEntity;

namespace SOSUrbano.Domain.Commands.CommandsIncident.IncidentStatusCommands.Update
{
    public class UpdateIncidentStatusResponse(string message)
    {
        public string Message { get; } = message;
    }
}
