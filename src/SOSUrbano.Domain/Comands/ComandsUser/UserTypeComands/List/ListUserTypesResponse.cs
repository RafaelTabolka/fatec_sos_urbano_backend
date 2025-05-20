using SOSUrbano.Domain.Entities.UserEntity;

namespace SOSUrbano.Domain.Comands.ComandsUser.UserTypeComands.List
{
    public class ListUserTypesResponse(IEnumerable<UserType> userTypes)
    {
        public IReadOnlyCollection<UserType> UserTypes { get; } = userTypes.ToList();
    }
}
