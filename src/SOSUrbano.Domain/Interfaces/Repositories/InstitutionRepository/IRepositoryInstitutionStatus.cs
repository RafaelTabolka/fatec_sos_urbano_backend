using SOSUrbano.Domain.Entities.InstitutionEntity;
using SOSUrbano.Domain.Interfaces.Repositories.Base;

namespace SOSUrbano.Domain.Interfaces.Repositories.InstitutionRepository
{
    public interface IRepositoryInstitutionStatus :
        IRepositoryBase<InstitutionStatus>
    {
        Task<InstitutionStatus> GetStatusByNameAsync(string name);
    }
}
