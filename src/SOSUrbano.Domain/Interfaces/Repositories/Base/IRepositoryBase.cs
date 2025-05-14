using SOSUrbano.Domain.Entities.Base;

namespace SOSUrbano.Domain.Interfaces.Repositories.Base
{
    public interface IRepositoryBase<TEntity> where TEntity : EntityBase
    {
        Task<TEntity?> GetByIdAsync(Guid id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task AddAsync(TEntity entity);
        void Update(TEntity entity);
        void Delete(Guid id);

        Task CommitAsync();

    }
}
