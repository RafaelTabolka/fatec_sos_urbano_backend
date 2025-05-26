using Microsoft.EntityFrameworkCore;
using SOSUrbano.Domain.Entities.IncidentEntity;
using SOSUrbano.Domain.Interfaces.Repositories.IncidentRepository;
using SOSUrbano.Infra.Data.Context;
using SOSUrbano.Infra.Data.Repository.Base;

namespace SOSUrbano.Infra.Data.Repository.IncidentRepository
{
    public class RepositoryIncidentStatus(SOSUrbanoContext context) :
        RepositoryBase<IncidentStatus>(context), IRepositoryIncidentStatus
    {
        private readonly SOSUrbanoContext _context = context;

        public async Task<IncidentStatus> GetIncidentStatusByNameAsync(string name)
        {
            var incidentStatus = await _context.IncidentStatusSet
                .FirstOrDefaultAsync(status =>
                EF.Functions.Like(status.Name, name));

            if (incidentStatus is null)
                throw new Exception("Status não encontrado.");

            return incidentStatus;
        }
    }
}
