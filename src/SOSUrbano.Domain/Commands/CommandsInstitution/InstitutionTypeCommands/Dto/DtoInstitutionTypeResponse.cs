namespace SOSUrbano.Domain.Commands.CommandsInstitution.InstitutionTypeCommands.Dto
{
    public class DtoInstitutionTypeResponse(Guid id, string name)
    {
        public Guid Id { get; } = id;
        public string Name { get; } = name;
    }
}
