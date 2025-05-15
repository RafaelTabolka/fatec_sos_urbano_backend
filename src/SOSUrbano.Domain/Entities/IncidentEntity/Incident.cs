using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SOSUrbano.Domain.Entities.Base;
using SOSUrbano.Domain.Entities.UserEntity;

namespace SOSUrbano.Domain.Entities.IncidentEntity
{
    public class Incident : EntityBase
    {
        public Guid UserId { get; set; }
        public User User { get; set; } = null!;
    }
}
