using SOSUrbano.Domain.Entities.Base;
using SOSUrbano.Domain.Entities.InstitutionEntity;
using SOSUrbano.Domain.Entities.UserEntity;

namespace SOSUrbano.Domain.Entities.IncidentEntity
{
    public class Incident : EntityBase
    {
        public string Description { get; set; } = string.Empty;

        public double LatLocalization { get; set; }

        public double LongLocalization { get; set; }
        
        public Guid UserId { get; set; }

        public User User { get; set; } = null!;

        public Guid InstitutionId { get; set; }
        
        public Institution Institution { get; set; } = null!;

        public Guid IncidentStatusId { get; set; }

        public IncidentStatus IncidentStatus { get; set; } = null!;

        public List<IncidentPhoto> IncidentPhotos { get; set; } = null!;

        public Incident (string description, double latLocalization,
            double longLocalization, Guid institutionId,
            Guid incidentStatusId, Guid userId)
        {
            Id = Guid.NewGuid();
            Description = description;
            LatLocalization = latLocalization;
            LongLocalization = longLocalization;
            InstitutionId = institutionId;
            IncidentStatusId = incidentStatusId;
            UserId = userId;
        }
    }
}
