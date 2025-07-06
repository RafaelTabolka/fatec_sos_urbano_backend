using SOSUrbano.Domain.Entities.IncidentEntity;
using SOSUrbano.Domain.Interfaces.Repositories.Base;

namespace SOSUrbano.Domain.Interfaces.Repositories.IncidentRepository
{
    public interface IRepositoryIncident : IRepositoryBase<Incident>
    {
        Task<IEnumerable<Incident>> GetAllIncidentsAsync();

        Task<Incident> GetIncidentByIdAsync(Guid id);

        Task<string> ConvertLatLogInAddress(double lat, double longi);
    }
}
