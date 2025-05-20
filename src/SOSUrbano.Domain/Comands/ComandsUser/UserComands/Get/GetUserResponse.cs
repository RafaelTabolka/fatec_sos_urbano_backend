using SOSUrbano.Domain.Entities.UserEntity;

namespace SOSUrbano.Domain.Comands.ComandsUser.UserComands.Get
{
    public class GetUserResponse(User user)
    {
        public User User { get; set; } = user;
    }
}
