using SOSUrbano.Domain.Entities.UserEntity;

namespace SOSUrbano.Domain.Comands.UserStatusComands.List
{
    public class ListUserStatusResponse(IEnumerable<UserStatus> userStatuses)
    {
        public IReadOnlyCollection<UserStatus> UserStatuses { get; } = userStatuses.ToList();
    }
}
