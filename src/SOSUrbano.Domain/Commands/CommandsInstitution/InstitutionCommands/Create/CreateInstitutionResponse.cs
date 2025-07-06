namespace SOSUrbano.Domain.Commands.CommandsInstitution.InstitutionCommands.Create
{
    public class CreateInstitutionResponse(Guid id, string message)
    {
        public Guid Id { get; } = id;
        public string Name { get; } = message;
    }
}
