namespace SOSUrbano.Domain.Commands.CommandsUser.UserPhoneCommands.Dto
{
    public class DtoUserPhoneResponse(Guid id, string number)
    {
        public Guid Id { get; } = id;
        public string Number { get; } = number;
    }
}
