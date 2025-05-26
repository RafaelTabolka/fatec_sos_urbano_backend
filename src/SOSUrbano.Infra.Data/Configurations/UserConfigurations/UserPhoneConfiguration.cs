using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SOSUrbano.Domain.Entities.UserEntity;

namespace SOSUrbano.Infra.Data.Configurations.UserConfigurations
{
    internal class UserPhoneConfiguration :
        IEntityTypeConfiguration<UserPhone>
    {
        public void Configure(EntityTypeBuilder<UserPhone> builder)
        {
            builder.HasKey(userPhone => userPhone.Id);

            builder.Property(userPhone => userPhone.Number)
                .HasMaxLength(11)
                .IsRequired();

            builder.ToTable("tb_user_phones");
        }
    }
}
