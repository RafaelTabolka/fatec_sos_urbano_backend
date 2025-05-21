using SOSUrbano.Domain.Entities.Base;

namespace SOSUrbano.Domain.Entities.UserEntity
{
    public class UserStatus : EntityBase
    {
        public string Name { get; set; } = string.Empty;

        public UserStatus(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
        }

        public void AlterName(string newName)
        {
            Name = newName;
        }
    }
}
