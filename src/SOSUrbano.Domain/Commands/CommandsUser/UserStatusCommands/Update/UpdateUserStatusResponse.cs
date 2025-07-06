using SOSUrbano.Domain.Entities.UserEntity;

namespace SOSUrbano.Domain.Commands.CommandsUser.UserStatusCommands.Update
{
    public class UpdateUserStatusResponse(string message)
    {
        public string Message { get; set; } = message;
    }
}
