using SOSUrbano.Domain.Entities.InstitutionEntity;
using SOSUrbano.Domain.Interfaces.Repositories.Base;

namespace SOSUrbano.Domain.Interfaces.Repositories.InstitutionRepository
{
    public interface IRepositoryInstitutionType :
        IRepositoryBase<InstitutionType>
    {
        Task<InstitutionType> GetTypeByNameAsync(string name);
    }
}
