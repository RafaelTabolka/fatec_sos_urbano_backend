namespace SOSUrbano.Domain.Commands.CommandsUser.UserStatusCommands.Delete
{
    public class DeleteUserStatusResponse(string message)
    {
        public string Message { get; } = message;
    }
}
