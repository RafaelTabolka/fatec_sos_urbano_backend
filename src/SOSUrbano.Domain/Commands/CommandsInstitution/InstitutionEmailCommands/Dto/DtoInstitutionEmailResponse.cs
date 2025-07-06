namespace SOSUrbano.Domain.Commands.CommandsInstitution.InstitutionEmailCommands.Dto
{
    public class DtoInstitutionEmailResponse(Guid id, string emailAddress)
    {
        public Guid Id { get; } = id;
        public string EmailAddress { get; } = emailAddress;
    }
}
