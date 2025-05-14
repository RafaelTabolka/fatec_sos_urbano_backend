using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SOSUrbano.Domain.Entities.UserEntity;

namespace SOSUrbano.Infra.Data.Configurations.UserConfigurations
{
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(p => p.Email)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(p => p.Cpf)
                .IsRequired()
                .HasMaxLength(11);

            builder.Property(p => p.Password)
                .IsRequired();

            builder.Property(p => p.UserStatusId)
                .IsRequired();

            builder.Property(p => p.UserTypeId)
                .IsRequired();

            builder.Property(p => p.UserPhones)
                .IsRequired(false);

            builder.Property(p => p.Incidents)
                .IsRequired(false);

            builder.ToTable("tb_user");
        }
    }
}
