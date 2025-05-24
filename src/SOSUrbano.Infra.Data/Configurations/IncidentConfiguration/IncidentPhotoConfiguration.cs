using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SOSUrbano.Domain.Entities.IncidentEntity;

namespace SOSUrbano.Infra.Data.Configurations.IncidentConfiguration
{
    public class IncidentPhotoConfiguration :
        IEntityTypeConfiguration<IncidentPhoto>
    {
        public void Configure(EntityTypeBuilder<IncidentPhoto> builder)
        {
            builder.HasKey(photo => photo.Id);

            builder.Property(photo => photo.SavedPath)
                .HasMaxLength(500);

            builder.ToTable("tb_incident_photos");
        }
    }
}
