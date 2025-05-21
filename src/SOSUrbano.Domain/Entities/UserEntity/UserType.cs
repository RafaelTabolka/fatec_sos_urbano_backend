using SOSUrbano.Domain.Entities.Base;

namespace SOSUrbano.Domain.Entities.UserEntity
{
    public class UserType : EntityBase
    {
        public string Name { get; set; } = string.Empty;

        public UserType(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
        }
    }
}
