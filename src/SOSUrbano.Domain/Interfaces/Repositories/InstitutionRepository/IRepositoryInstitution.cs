﻿using SOSUrbano.Domain.Entities.InstitutionEntity;
using SOSUrbano.Domain.Interfaces.Repositories.Base;

namespace SOSUrbano.Domain.Interfaces.Repositories.InstitutionRepository
{
    public interface IRepositoryInstitution:
        IRepositoryBase<Institution>
    {
        Task<IEnumerable<Institution>> GetAllInstitutions();

        Task<Institution> GetInstitutionByNameAsync(string name);

        Task<Institution> GetInstitutionByIdAsync(Guid id);
    }
}
