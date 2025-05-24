using SOSUrbano.Domain.Entities.UserEntity;

namespace SOSUrbano.Domain.Comands.ComandsUser.UserComands.Update
{
    public class UpdateUserResponse(User user)
    {
        public User User { get; } = user;
    }
}
