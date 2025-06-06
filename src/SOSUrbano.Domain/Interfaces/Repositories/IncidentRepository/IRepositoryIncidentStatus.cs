﻿using SOSUrbano.Domain.Entities.IncidentEntity;
using SOSUrbano.Domain.Interfaces.Repositories.Base;

namespace SOSUrbano.Domain.Interfaces.Repositories.IncidentRepository
{
    public interface IRepositoryIncidentStatus : 
        IRepositoryBase<IncidentStatus>
    {
        Task<IncidentStatus> GetIncidentStatusByNameAsync(string name);
    }
}
