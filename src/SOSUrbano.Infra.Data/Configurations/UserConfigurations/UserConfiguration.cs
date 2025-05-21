using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SOSUrbano.Domain.Entities.UserEntity;

namespace SOSUrbano.Infra.Data.Configurations.UserConfigurations
{
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(user => user.Id);

            builder.Property(user => user.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(user => user.Email)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(user => user.Cpf)
                .IsRequired()
                .HasMaxLength(11);

            builder.Property(user => user.Password)
                .IsRequired();

            builder.HasOne(user => user.UserStatus)
                .WithMany()
                .HasForeignKey(status => status.UserStatusId)
                .IsRequired();
                

            builder.HasOne(user => user.UserType)
                .WithMany()
                .HasForeignKey(type => type.UserTypeId)
                .IsRequired();

            builder.HasMany(user => user.UserPhones)
                .WithOne(phone => phone.User)
                .HasForeignKey(phone => phone.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(user => user.Incidents)
                .WithOne(incident => incident.User)
                .HasForeignKey(incident => incident.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.ToTable("tb_users");
        }
    }
}
