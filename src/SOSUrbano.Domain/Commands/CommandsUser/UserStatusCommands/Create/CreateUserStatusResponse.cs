namespace SOSUrbano.Domain.Commands.CommandsUser.UserStatusCommands.Create
{
    public class CreateUserStatusResponse(Guid id, string message)
    {
        public Guid Id { get; } = id;
        public string Message { get; } = message;
    }
}
