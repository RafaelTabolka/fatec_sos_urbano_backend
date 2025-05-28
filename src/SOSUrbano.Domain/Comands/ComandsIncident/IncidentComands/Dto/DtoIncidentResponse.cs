using SOSUrbano.Domain.Comands.ComandsIncident.IncidentPhotoComands.Dto;
using SOSUrbano.Domain.Comands.ComandsIncident.IncidentStatusComands.Dto;

namespace SOSUrbano.Domain.Comands.ComandsIncident.IncidentComands.Dto
{
    public class DtoIncidentResponse(
        Guid id,
        string description,
        double latLocalization,
        double longLocalization,
        DtoIncidentStatusResponse incidentStatus,
        List<DtoIncidentPhotoResponse> incidentPhotos,
        Guid userId,
        Guid institutionId)
    {
        public Guid Id { get; } = id;

        public string Description { get; } = description;

        public double LatLocalization { get; } = latLocalization;

        public double LongLocalization { get; } = longLocalization;

        public DtoIncidentStatusResponse IncidentStauts { get; } = incidentStatus;

        public List<DtoIncidentPhotoResponse> IncidentPhotos { get; } = incidentPhotos;

        public Guid UserId { get; } = userId;

        public Guid InstitutionId { get; } = institutionId;
    }
}
