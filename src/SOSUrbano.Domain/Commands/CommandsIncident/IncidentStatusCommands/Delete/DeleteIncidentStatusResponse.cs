namespace SOSUrbano.Domain.Commands.CommandsIncident.IncidentStatusCommands.Delete
{
    public class DeleteIncidentStatusResponse(string message)
    {
        public string Message { get; } = message;
    }
}
