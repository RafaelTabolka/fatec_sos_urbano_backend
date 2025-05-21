using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SOSUrbano.Domain.Entities.InstitutionEntity;

namespace SOSUrbano.Infra.Data.Configurations.InstitutionConfigurations
{
    internal class InstitutionStatusConfiguration :
        IEntityTypeConfiguration<InstitutionStatus>
    {
        public void Configure(EntityTypeBuilder<InstitutionStatus> builder)
        {
            builder.HasKey(status => status.Id);

            builder.Property(status => status.Name)
                .HasMaxLength(20)
                .IsRequired();

            builder.ToTable("tb_institution_statuses");
        }
    }
}
