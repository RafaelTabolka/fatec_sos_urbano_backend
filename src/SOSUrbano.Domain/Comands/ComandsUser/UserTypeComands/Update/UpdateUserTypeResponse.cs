using SOSUrbano.Domain.Entities.UserEntity;

namespace SOSUrbano.Domain.Comands.ComandsUser.UserTypeComands.Update
{
    public class UpdateUserTypeResponse(UserType userType)
    {
        public UserType UserType { get; } = userType;
    }
}
