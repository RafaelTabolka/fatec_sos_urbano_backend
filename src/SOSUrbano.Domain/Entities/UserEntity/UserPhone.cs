using SOSUrbano.Domain.Entities.Base;

namespace SOSUrbano.Domain.Entities.UserEntity
{
    public class UserPhone : EntityBase
    {
        public Guid UserId { get; set; }
        public User User { get; set; } = null!;
        public string Number { get; set; } = null!;

        public UserPhone(Guid userId, string number)
        {
            Id = Guid.NewGuid();
            UserId = userId;
            Number = number;
        }
    }
}
