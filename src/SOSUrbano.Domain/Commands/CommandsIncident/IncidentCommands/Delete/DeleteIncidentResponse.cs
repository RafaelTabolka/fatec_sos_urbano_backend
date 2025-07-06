namespace SOSUrbano.Domain.Commands.CommandsIncident.IncidentCommands.Delete
{
    public class DeleteIncidentResponse(string message)
    {
        public string Message { get; } = message;
    }
}
