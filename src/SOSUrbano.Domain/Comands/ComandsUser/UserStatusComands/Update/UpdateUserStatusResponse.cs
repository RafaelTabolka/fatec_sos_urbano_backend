using SOSUrbano.Domain.Entities.UserEntity;

namespace SOSUrbano.Domain.Comands.ComandsUser.UserStatusComands.Update
{
    public class UpdateUserStatusResponse(UserStatus userStatus)
    {
        public UserStatus UserStatus { get; set; } = userStatus;
    }
}
