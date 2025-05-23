﻿using Microsoft.EntityFrameworkCore;
using SOSUrbano.Domain.Entities.InstitutionEntity;
using SOSUrbano.Domain.Interfaces.Repositories.InstitutionRepository;
using SOSUrbano.Infra.Data.Context;
using SOSUrbano.Infra.Data.Repository.Base;

namespace SOSUrbano.Infra.Data.Repository.InstitutionRepository
{
    public class RepositoryInstitution
        (SOSUrbanoContext context) :
        RepositoryBase<Institution>(context),
        IRepositoryInstitution
    {
        private readonly SOSUrbanoContext _context = context;
        public async Task<IEnumerable<Institution>> GetAllInstitutions()
        {
            var institutions = await _context.InstitutionSet
                .Include(i => i.InstitutionStatus)
                .Include(i => i.InstitutionType)
                .Include(i => i.InstitutionEmails)
                .Include(i => i.InstitutionPhones)
                .Include(i => i.Incidents)
                .ToListAsync();

            return institutions;    
        }
    }
}
