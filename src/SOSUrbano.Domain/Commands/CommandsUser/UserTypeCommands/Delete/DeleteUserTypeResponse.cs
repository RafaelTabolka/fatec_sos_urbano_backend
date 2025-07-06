namespace SOSUrbano.Domain.Commands.CommandsUser.UserTypeCommands.Delete
{
    public class DeleteUserTypeResponse(string message)
    {
        public string Message { get; } = message;
    }
}
