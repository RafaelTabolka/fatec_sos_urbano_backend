using SOSUrbano.Domain.Comands.ComandsIncident.IncidentPhotoComands.Create;
using SOSUrbano.Domain.Entities.IncidentEntity;

namespace SOSUrbano.Domain.Comands.ComandsIncident.IncidentComands.Create
{
    public class CreateIncidentResponse
        (Guid id, string description, string institutionName, 
        string incidentStatusName, double latLocalization,
        double longLocalization, List<IncidentPhoto> incidentPhotos,
        Guid userId)
    {
        public Guid Id { get; } = id;
        public string Description { get; } = description;
        
        public string InstitutionName { get; } = institutionName;

        public string IncidentStatusName { get; } = incidentStatusName;

        public double LatLocalization { get; } = latLocalization;

        public double LongLocalization { get; } = longLocalization;

        public List<IncidentPhoto> IncidentPhotos { get; } = incidentPhotos;

        public Guid UserId { get; } = userId;
    }
}
