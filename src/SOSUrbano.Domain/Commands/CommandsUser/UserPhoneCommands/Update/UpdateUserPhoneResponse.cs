using SOSUrbano.Domain.Entities.UserEntity;

namespace SOSUrbano.Domain.Commands.CommandsUser.UserPhoneCommands.Update
{
    public class UpdateUserPhoneResponse(string message)
    {
        public string Message { get; } = message;
    }
}
