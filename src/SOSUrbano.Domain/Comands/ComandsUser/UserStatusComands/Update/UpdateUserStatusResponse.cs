using SOSUrbano.Domain.Entities.UserEntity;

namespace SOSUrbano.Domain.Comands.ComandsUser.UserStatusComands.Update
{
    public class UpdateUserStatusResponse(string message)
    {
        public string Message { get; set; } = message;
    }
}
