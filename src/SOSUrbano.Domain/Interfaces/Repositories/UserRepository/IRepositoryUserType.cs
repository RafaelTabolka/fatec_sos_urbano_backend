using SOSUrbano.Domain.Entities.UserEntity;
using SOSUrbano.Domain.Interfaces.Repositories.Base;

namespace SOSUrbano.Domain.Interfaces.Repositories.UserRepository
{
    public interface IRepositoryUserType : IRepositoryBase<UserType>
    {
        Task<UserType> GetTypeByNameAsync(string name);
    }
}
