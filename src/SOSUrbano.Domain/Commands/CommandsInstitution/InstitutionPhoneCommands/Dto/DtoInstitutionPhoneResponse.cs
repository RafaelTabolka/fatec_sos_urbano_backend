namespace SOSUrbano.Domain.Commands.CommandsInstitution.InstitutionPhoneCommands.Dto
{
    public class DtoInstitutionPhoneResponse(Guid id, string number)
    {
        public Guid Id { get; } = id;
        public string Number { get; } = number;
    }
}
