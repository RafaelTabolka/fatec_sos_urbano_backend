using SOSUrbano.Domain.Entities.UserEntity;

namespace SOSUrbano.Domain.Comands.ComandsUser.UserPhoneComands.Update
{
    public class UpdateUserPhoneResponse(string message)
    {
        public string Message { get; } = message;
    }
}
