using SOSUrbano.Domain.Entities.Base;

namespace SOSUrbano.Domain.Entities.IncidentEntity
{
    public class IncidentPhoto : EntityBase
    {
        public string SavedPath { get; set; } = string.Empty;

        public Guid IncidentId { get; set; }
    }
}
