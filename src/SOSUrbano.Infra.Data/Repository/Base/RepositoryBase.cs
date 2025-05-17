using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SOSUrbano.Domain.Entities.Base;
using SOSUrbano.Domain.Interfaces.Repositories.Base;
using SOSUrbano.Infra.Data.Context;

namespace SOSUrbano.Infra.Data.Repository.Base
{
    public class RepositoryBase<TEntity>(SOSUrbanoContext context) : 
        IRepositoryBase<TEntity> where TEntity : EntityBase
    {

        protected readonly DbSet<TEntity> DbSet = context.Set<TEntity>();

        public async Task<TEntity?> GetByIdAsync(Guid id)
        {
            return await DbSet.FindAsync(id);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await DbSet.ToListAsync();
        }

        public async Task AddAsync(TEntity entity)
        {
            await DbSet.AddAsync(entity);
        }

        public void Update(TEntity entity)
        {
            DbSet.Update(entity);
        }

        public void Delete(Guid id)
        {
            var entity = DbSet.Find(id);

            if (entity is not null)
                DbSet.Remove(entity);
        }

        public async Task CommitAsync()
        {
           await context.SaveChangesAsync();
        }
    }
}
