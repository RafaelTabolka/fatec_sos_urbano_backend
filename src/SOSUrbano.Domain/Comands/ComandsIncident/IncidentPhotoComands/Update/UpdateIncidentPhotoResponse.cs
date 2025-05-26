using SOSUrbano.Domain.Entities.IncidentEntity;

namespace SOSUrbano.Domain.Comands.ComandsIncident.IncidentPhotoComands.Update
{
    public class UpdateIncidentPhotoResponse(IncidentPhoto incidentPhoto)
    {
        public IncidentPhoto IncidentPhoto { get; } = incidentPhoto;
    }
}
