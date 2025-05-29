using SOSUrbano.Domain.Entities.UserEntity;

namespace SOSUrbano.Domain.Comands.ComandsUser.UserTypeComands.Update
{
    public class UpdateUserTypeResponse(string message)
    {
        public string Message { get; } = message;
    }
}
