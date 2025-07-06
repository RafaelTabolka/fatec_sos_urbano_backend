using SOSUrbano.Domain.Entities.UserEntity;

namespace SOSUrbano.Domain.Commands.CommandsUser.UserStatusCommands.List
{
    public class ListUserStatusResponse(IEnumerable<UserStatus> userStatuses)
    {
        public IReadOnlyCollection<UserStatus> UserStatuses { get; } = userStatuses.ToList();
    }
}
