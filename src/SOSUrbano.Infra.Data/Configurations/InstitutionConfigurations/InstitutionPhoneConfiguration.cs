using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SOSUrbano.Domain.Entities.InstitutionEntity;

namespace SOSUrbano.Infra.Data.Configurations.InstitutionConfigurations
{
    internal class InstitutionPhoneConfiguration :
        IEntityTypeConfiguration<InstitutionPhone>
    {
        public void Configure(EntityTypeBuilder<InstitutionPhone> builder)
        {
            builder.HasKey(phone => phone.Id);

            builder.Property(phone => phone.Number)
                .HasMaxLength(11)
                .IsRequired();

            builder.ToTable("tb_institution_phones");
        }
    }
}
