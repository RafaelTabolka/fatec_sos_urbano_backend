using SOSUrbano.Domain.Entities.IncidentEntity;

namespace SOSUrbano.Domain.Commands.CommandsIncident.IncidentCommands.Update
{
    public class UpdateIncidentResponse(string message)
    {
        public string Message { get; } = message;
    }
}
