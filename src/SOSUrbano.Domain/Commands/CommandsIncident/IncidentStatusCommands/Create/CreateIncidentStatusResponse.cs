namespace SOSUrbano.Domain.Commands.CommandsIncident.IncidentStatusCommands.Create
{
    public class CreateIncidentStatusResponse(Guid id, string message)
    {
        public Guid Id { get; } = id;
        public string Message { get; } = message;
    }
}
