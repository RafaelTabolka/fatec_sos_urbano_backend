using SOSUrbano.Domain.Entities.IncidentEntity;
using SOSUrbano.Domain.Entities.UserEntity;

namespace SOSUrbano.Domain.Comands.UserPhoneComands.Create
{
    public class CreateUserPhoneRequest
    {
        public string Number { get; set; } = null!;
    }
}
