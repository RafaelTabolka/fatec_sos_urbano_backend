using SOSUrbano.Domain.Entities.UserEntity;

namespace SOSUrbano.Domain.Commands.CommandsUser.UserTypeCommands.Update
{
    public class UpdateUserTypeResponse(string message)
    {
        public string Message { get; } = message;
    }
}
