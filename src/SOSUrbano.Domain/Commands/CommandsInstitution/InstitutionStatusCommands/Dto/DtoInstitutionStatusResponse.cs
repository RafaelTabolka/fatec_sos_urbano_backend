namespace SOSUrbano.Domain.Commands.CommandsInstitution.InstitutionStatusCommands.Dto
{
    public class DtoInstitutionStatusResponse(Guid id, string name)
    {
        public Guid Id { get; } = id;
        public string Name { get; } = name;
    }
}
