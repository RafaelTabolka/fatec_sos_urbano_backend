using SOSUrbano.Domain.Comands.ComandsUser.UserComands.Dto;
using SOSUrbano.Domain.Entities.UserEntity;

namespace SOSUrbano.Domain.Comands.ComandsUser.UserComands.Get
{
    public class GetUserResponse(DtoUserResponse user)
    {
        public DtoUserResponse User { get; set; } = user;
    }
}
