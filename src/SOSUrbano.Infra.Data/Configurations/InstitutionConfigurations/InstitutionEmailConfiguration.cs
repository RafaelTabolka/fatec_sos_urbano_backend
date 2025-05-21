using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SOSUrbano.Domain.Entities.InstitutionEntity;

namespace SOSUrbano.Infra.Data.Configurations.InstitutionConfigurations
{
    internal class InstitutionEmailConfiguration :
        IEntityTypeConfiguration<InstitutionEmail>
    {
        public void Configure(EntityTypeBuilder<InstitutionEmail> builder)
        {
            builder.HasKey(email => email.Id);

            builder.Property(email => email.EmailAddress)
                .HasMaxLength(50)
                .IsRequired();

            builder.ToTable("tb_institution_emails");
        }
    }
}
