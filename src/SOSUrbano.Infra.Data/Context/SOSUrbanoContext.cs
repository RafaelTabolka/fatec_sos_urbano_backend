﻿using System.Reflection;
using Microsoft.EntityFrameworkCore;
using SOSUrbano.Domain.Entities.Base;
using SOSUrbano.Domain.Entities.IncidentEntity;
using SOSUrbano.Domain.Entities.InstitutionEntity;
using SOSUrbano.Domain.Entities.UserEntity;
using SOSUrbano.Infra.CrossCutting.Extensions;

namespace SOSUrbano.Infra.Data.Context
{
    public class SOSUrbanoContext(DbContextOptions<SOSUrbanoContext> options) :
        DbContext(options)
    {
        public DbSet<User> UserSet { get; set; }
        public DbSet<UserStatus> UserStatusesSet { get; set; }
        public DbSet<UserPhone> UserPhoneSet { get; set; }
        public DbSet<UserType> UserTypeSet { get; set; }
        public DbSet<Incident> IncidentSet { get; set; }
        public DbSet<IncidentPhoto> IncidentPhotoSet { get; set; }
        public DbSet<IncidentStatus> IncidentStatusSet { get; set; }
        public DbSet<Institution> InstitutionSet { get; set; }
        public DbSet<InstitutionEmail> InstitutionEmailSet { get; set; }
        public DbSet<InstitutionPhone> InstitutionPhoneSet { get; set; }
        public DbSet<InstitutionStatus> InstitutionStatusSet { get; set; }
        public DbSet<InstitutionType> InstitutionTypeSet { get; set; }

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
