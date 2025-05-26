using SOSUrbano.Domain.Entities.UserEntity;

namespace SOSUrbano.Domain.Comands.ComandsUser.UserPhoneComands.Update
{
    public class UpdateUserPhoneResponse(UserPhone userPhone)
    {
        public UserPhone UserPhone { get; } = userPhone;
    }
}
