using Microsoft.EntityFrameworkCore;
using SOSUrbano.Domain.Entities.IncidentEntity;
using SOSUrbano.Domain.Interfaces.Repositories.IncidentRepository;
using SOSUrbano.Infra.Data.Context;
using SOSUrbano.Infra.Data.Repository.Base;

namespace SOSUrbano.Infra.Data.Repository.IncidentRepository
{
    public class RepositoryIncident(SOSUrbanoContext context) :
        RepositoryBase<Incident>(context), IRepositoryIncident
    {
        private readonly SOSUrbanoContext _context = context;

        public async Task<IEnumerable<Incident>> GetAllIncidentsAsync()
        {
            var incidents = await _context.IncidentSet
                .Include(i => i.IncidentStatus)
                .Include(i => i.IncidentPhotos)
                .ToListAsync();

            return incidents;
        }

        public async Task<Incident> GetIncidentByIdAsync(Guid id)
        {
            var incident = await _context.IncidentSet
                .Include(i => i.IncidentStatus)
                .Include(i => i.IncidentPhotos)
                .FirstOrDefaultAsync(i => i.Id == id);

            if (incident is null)
                throw new Exception("Denúncia não encontrada.");

            return incident;
        }
    }
}
