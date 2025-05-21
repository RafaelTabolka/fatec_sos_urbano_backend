using System;
using System.Collections.Generic;
using System.Linq;
using SOSUrbano.Domain.Entities.Base;
using SOSUrbano.Domain.Entities.InstitutionEntity;
using SOSUrbano.Domain.Entities.UserEntity;

namespace SOSUrbano.Domain.Entities.IncidentEntity
{
    public class Incident : EntityBase
    {
        public Guid UserId { get; set; }
        public User User { get; set; } = null!;
        public Guid InstitutionId { get; set; }
        public Institution Institution { get; set; } = null!;

    }
}
