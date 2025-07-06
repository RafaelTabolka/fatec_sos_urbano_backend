using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SOSUrbano.Domain.Entities.IncidentEntity;

namespace SOSUrbano.Infra.Data.Configurations.IncidentConfiguration
{
    public class IncidentStatusConfiguration :
        IEntityTypeConfiguration<IncidentStatus>
    {
        public void Configure(EntityTypeBuilder<IncidentStatus> builder)
        {
            builder.HasKey(status => status.Id);

            builder.Property(status => status.Name)
                .HasMaxLength(50);

            builder.ToTable("tb_incident_statuses");
        }
    }
}
