using SOSUrbano.Domain.Entities.InstitutionEntity;
using SOSUrbano.Domain.Interfaces.Repositories.InstitutionRepository;
using SOSUrbano.Infra.Data.Context;
using SOSUrbano.Infra.Data.Repository.Base;

namespace SOSUrbano.Infra.Data.Repository.InstitutionRepository
{
    public class RepositoryInstitutionStatus
        (SOSUrbanoContext context) :
        RepositoryBase<InstitutionStatus>(context),
        IRepositoryInstitutionStatus
    {
    }
}
