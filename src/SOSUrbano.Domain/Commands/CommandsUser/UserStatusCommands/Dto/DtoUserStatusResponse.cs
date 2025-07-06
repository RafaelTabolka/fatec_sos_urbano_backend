namespace SOSUrbano.Domain.Commands.CommandsUser.UserStatusCommands.Dto
{
    public class DtoUserStatusResponse(Guid id, string name)
    {
        public Guid Id { get; } = id;
        public string Name { get; } = name;
    }
}
