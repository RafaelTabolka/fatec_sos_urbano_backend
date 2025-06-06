﻿using SOSUrbano.Domain.Entities.Base;

namespace SOSUrbano.Domain.Entities.IncidentEntity
{
    public class IncidentStatus : EntityBase
    {
        public string Name { get; set; } = string.Empty;

        public IncidentStatus (string name)
        {
            Id = Guid.NewGuid();
            Name = name;
        }
    }
}
