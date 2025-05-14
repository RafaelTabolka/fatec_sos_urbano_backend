using SOSUrbano.Domain.Entities.UserEntity;
using SOSUrbano.Domain.Interfaces.Repositories.Base;

namespace SOSUrbano.Domain.Interfaces.Repositories.UserRepository
{
    public interface IRepositoryUser : IRepositoryBase<User>
    {
        Task<IEnumerable<User>> ListByName(string name);
    }
}
