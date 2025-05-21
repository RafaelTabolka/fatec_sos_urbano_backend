using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SOSUrbano.Domain.Entities.InstitutionEntity;

namespace SOSUrbano.Infra.Data.Configurations.InstitutionConfigurations
{
    internal class InstitutionTypeConfiguration :
        IEntityTypeConfiguration<InstitutionType>
    {
        public void Configure(EntityTypeBuilder<InstitutionType> builder)
        {
            builder.HasKey(type => type.Id);

            builder.Property(type => type.Name)
                .HasMaxLength(20)
                .IsRequired();

            builder.ToTable("tb_institution_types");
        }
    }
}
