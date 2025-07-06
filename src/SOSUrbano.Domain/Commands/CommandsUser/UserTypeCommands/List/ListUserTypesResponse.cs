using SOSUrbano.Domain.Entities.UserEntity;

namespace SOSUrbano.Domain.Commands.CommandsUser.UserTypeCommands.List
{
    public class ListUserTypesResponse(IEnumerable<UserType> userTypes)
    {
        public IReadOnlyCollection<UserType> UserTypes { get; } = userTypes.ToList();
    }
}
