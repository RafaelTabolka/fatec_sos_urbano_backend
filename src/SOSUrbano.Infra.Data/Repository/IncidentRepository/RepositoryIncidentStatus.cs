using SOSUrbano.Domain.Entities.IncidentEntity;
using SOSUrbano.Domain.Interfaces.Repositories.IncidentRepository;
using SOSUrbano.Infra.Data.Context;
using SOSUrbano.Infra.Data.Repository.Base;

namespace SOSUrbano.Infra.Data.Repository.IncidentRepository
{
    public class RepositoryIncidentStatus(SOSUrbanoContext context) :
        RepositoryBase<IncidentStatus>(context), IRepositoryIncidentStatus
    {
    }
}
