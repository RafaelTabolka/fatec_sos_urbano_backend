using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SOSUrbano.Domain.Entities.IncidentEntity;

namespace SOSUrbano.Infra.Data.Configurations.IncidentConfiguration
{
    public class IncidentConfiguration :
        IEntityTypeConfiguration<Incident>
    {
        public void Configure(EntityTypeBuilder<Incident> builder)
        {
            builder.HasKey(incident => incident.Id);

            builder.Property(incident => incident.LatLocalization);

            builder.Property(incident => incident.LongLocalization);

            builder.Property(incident => incident.TermsOfUse);

            builder.HasOne(incident => incident.User)
                .WithMany()
                .HasForeignKey(incident => incident.UserId);

            builder.HasOne(incident => incident.Institution)
                .WithMany()
                .HasForeignKey(incident => incident.InstitutionId);

            builder.HasOne(incident => incident.IncidentStatus)
                .WithMany()
                .HasForeignKey(incident => incident.IncidentStatusId);

            builder.HasMany(incident => incident.IncidentPhotos)
                .WithOne()
                .HasForeignKey(photo => photo.IncidentId);

            builder.ToTable("tb_incidents");
        }
    }
}
