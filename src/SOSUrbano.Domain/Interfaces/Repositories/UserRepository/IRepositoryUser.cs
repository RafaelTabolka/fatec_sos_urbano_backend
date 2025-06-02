using SOSUrbano.Domain.Entities.UserEntity;
using SOSUrbano.Domain.Interfaces.Repositories.Base;

namespace SOSUrbano.Domain.Interfaces.Repositories.UserRepository
{
    public interface IRepositoryUser : IRepositoryBase<User>
    {
        Task<IEnumerable<User>> ListByNameAsync(string name);

        Task<User> GetUserByIdAsync(Guid id);
        
        Task<User> GetByEmailAndPasswordAsync(string email, string password);

        Task<IEnumerable<User>> GetAllUsersAsync();

        Task<bool> ThisEmailExist(string email);
    }
}
