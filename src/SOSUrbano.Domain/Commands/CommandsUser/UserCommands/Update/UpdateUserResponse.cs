using SOSUrbano.Domain.Entities.UserEntity;

namespace SOSUrbano.Domain.Commands.CommandsUser.UserCommands.Update
{
    public class UpdateUserResponse(string message)
    {
        public string Message { get; } = message;
    }
}
