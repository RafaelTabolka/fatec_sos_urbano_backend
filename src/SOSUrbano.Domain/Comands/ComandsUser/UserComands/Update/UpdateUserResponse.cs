using SOSUrbano.Domain.Entities.UserEntity;

namespace SOSUrbano.Domain.Comands.ComandsUser.UserComands.Update
{
    public class UpdateUserResponse(string message)
    {
        public string Message { get; } = message;
    }
}
