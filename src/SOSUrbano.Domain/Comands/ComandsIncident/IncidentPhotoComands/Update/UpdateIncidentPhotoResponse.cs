using SOSUrbano.Domain.Entities.IncidentEntity;

namespace SOSUrbano.Domain.Comands.ComandsIncident.IncidentPhotoComands.Update
{
    public class UpdateIncidentPhotoResponse(string message)
    {
        public string Message { get; } = message;
    }
}
