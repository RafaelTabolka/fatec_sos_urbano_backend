using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SOSUrbano.Domain.Entities.UserEntity;

namespace SOSUrbano.Infra.Data.Configurations.UserConfigurations
{
    internal class UserPhoneConfiguration :
        IEntityTypeConfiguration<UserType>
    {
        public void Configure(EntityTypeBuilder<UserType> builder)
        {
            builder.HasKey(userPhone => userPhone.Id);

            builder.Property(userPhone => userPhone.Name)
                .HasMaxLength(20)
                .IsRequired();

            builder.ToTable("tb_user_phones");
        }
    }
}
