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

            builder.HasOne(u => u.UserStatus)
                .WithMany()
                .HasForeignKey(u => u.UserStatusId)
                .IsRequired();
                

            builder.HasOne(u => u.UserType)
                .WithMany()
                .HasForeignKey(u => u.UserTypeId)
                .IsRequired();

            builder.HasMany(user => user.UserPhones)
                .WithOne(userPhone => userPhone.User)
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
