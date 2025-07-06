namespace SOSUrbano.Domain.Commands.CommandsIncident.IncidentStatusCommands.Dto
{
    public class DtoIncidentStatusResponse(Guid id, string name)
    {
        public Guid Id { get; } = id;
        public string Name { get; } = name;
    }
}
