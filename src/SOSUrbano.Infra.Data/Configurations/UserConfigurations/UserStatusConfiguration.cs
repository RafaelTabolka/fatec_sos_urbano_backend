using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SOSUrbano.Domain.Entities.UserEntity;

namespace SOSUrbano.Infra.Data.Configurations.UserConfigurations
{
    internal class UserStatusConfiguration : 
        IEntityTypeConfiguration<UserStatus>
    {
        public void Configure(EntityTypeBuilder<UserStatus> builder)
        {
            builder.HasKey(userStatus => userStatus.Id);

            builder.Property(userStatus => userStatus.Name)
                .HasMaxLength(20)
                .IsRequired();

            builder.ToTable("tb_user_statuses");
        }
    }
}
