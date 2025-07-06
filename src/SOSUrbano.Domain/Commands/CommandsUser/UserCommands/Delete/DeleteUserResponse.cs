namespace SOSUrbano.Domain.Commands.CommandsUser.UserCommands.Delete
{
    public class DeleteUserResponse(string message)
    {
        public string Message { get; } = message;
    }
}
