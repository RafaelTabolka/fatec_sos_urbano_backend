using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SOSUrbano.Domain.Entities.InstitutionEntity;

namespace SOSUrbano.Infra.Data.Configurations.InstitutionConfigurations
{
    internal class InstitutionConfiguration :
        IEntityTypeConfiguration<Institution>
    {
        public void Configure(EntityTypeBuilder<Institution> builder)
        {
            builder.HasKey(inst => inst.Id);

            // Campo Simples
            builder.Property(inst => inst.Name)
                .HasMaxLength(50)
                .IsRequired();

            // Campo Simples
            builder.Property(inst => inst.Cnpj)
                .HasMaxLength(14)
                .IsRequired();

            // Campo Simples
            builder.Property(inst => inst.UrlSite)
                .HasMaxLength(200)
                .IsRequired(false);

            // Campo Simples
            builder.Property(inst => inst.Description)
                .HasMaxLength(500)
                .IsRequired();

            // Campo Simples
            builder.Property(inst => inst.Address)
                .HasMaxLength(100)
                .IsRequired();

            // Relação InstitutionStatus
            builder.HasOne(inst => inst.InstitutionStatus)
                .WithMany()
                .HasForeignKey(inst => inst.InstitutionStatusId)
                .IsRequired();

            // Relação InstitutionEmail
            builder.HasMany(inst => inst.InstitutionEmails)
                .WithOne()
                .HasForeignKey(email => email.InstitutionId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            // Relação InstitutionPhone
            builder.HasMany(inst => inst.InstitutionPhones)
                .WithOne()
                .HasForeignKey(phone => phone.InstitutionId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            // Relação InstitutionType
            builder.HasOne(inst => inst.InstitutionType)
                .WithMany()
                .HasForeignKey(inst => inst.InstitutionTypeId)
                .IsRequired();

            // Relação Incidents
            builder.HasMany(inst => inst.Incidents)
                .WithOne(incident => incident.Institution)
                .HasForeignKey(incident => incident.InstitutionId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired(false);

            builder.ToTable("tb_institutions");
        }
    }
}
