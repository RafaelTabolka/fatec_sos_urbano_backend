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
    internal class UserTypeConfiguration :
        IEntityTypeConfiguration<UserType>
    {
        public void Configure(EntityTypeBuilder<UserType> builder)
        {
            builder.HasKey(userType => userType.Id);

            builder.Property(userType => userType.Name)
                .HasMaxLength(50)
                .IsRequired();

            builder.ToTable("tb_user_types");
        }
    }
}
