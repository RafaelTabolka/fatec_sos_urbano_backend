using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SOSUrbano.Domain.Entities.Base;
using SOSUrbano.Domain.Entities.UserEntity;
using SOSUrbano.Infra.CrossCutting.Extensions;
using SOSUrbano.Infra.Data.Configurations.UserConfigurations;

namespace SOSUrbano.Infra.Data.Context
{
    internal class SOSUrbanoContext : DbContext
    {
        public DbSet<User> UserSet { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }

        /*
         SaveChanges é uma função do EntityFrameWork utilizada para 
        salvar mudanças realizadas num contexto
         */

        /*
         base.SaveChanges() chama a classe original do EF que salva as 
        informações no banco de fato. Então o método está sobrescrevendo o 
        método original quando se utiliza override, e depois é chamado o método
        base, original, utilizando o base.SaveChanges().
         */
        public override int SaveChanges()
        {
            SetInfoAdded();
            SetInfoUpdated();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            SetInfoAdded();
            SetInfoUpdated();
            return base.SaveChangesAsync(cancellationToken);
        }

        protected virtual void SetInfoAdded()
        {
            GetEntitiesEntries<EntityBase>(EntityState.Added)
                .ForEach(entity =>
                {
                    entity.CreatedAt = DateTime.UtcNow;
                });
        }

        protected virtual void SetInfoUpdated()
        {
            GetEntitiesEntries<EntityBase>(EntityState.Modified)
                .ForEach(entity =>
                {
                    entity.UpdatedAt = DateTime.UtcNow;
                });
        }

        private IEnumerable<TEntityBase> GetEntitiesEntries<TEntityBase>(EntityState entityState)
        {
            /*
            Quando manipulamos entidades com o Entity Framework 
            (como adicionar, atualizar ou remover),
            o contexto rastreia o estado de cada entidade internamente 
            (Added, Modified, Deleted, Unchanged...).

            A função abaixo retorna todas as entidades do tipo TEntityBase 
            que estão com o estado igual ao passado por parâmetro (entityState),
            usando o ChangeTracker.

            Isso pode ser útil, por exemplo, para aplicar regras antes de salvar
            ou fazer logs.

            ChangeTracker.Entries() retorna todas as entidades que estão sendo
            rastradas internamente e seus estados.

            A filtragem abaixo pega somente os estados que forem iguais ao do 
            parâmetro passado na função.

            Isso ainda não executa SQL, é uma filtragem na memória das entidades
            que o contexto está rastreando
            */
            return from e in ChangeTracker.Entries()
                   where e.Entity is TEntityBase && e.State == entityState
                   select (TEntityBase)e.Entity;  
        }
    }
}
