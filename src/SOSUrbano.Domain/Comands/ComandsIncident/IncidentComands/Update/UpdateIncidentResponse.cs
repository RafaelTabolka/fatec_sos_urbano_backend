using SOSUrbano.Domain.Entities.IncidentEntity;

namespace SOSUrbano.Domain.Comands.ComandsIncident.IncidentComands.Update
{
    public class UpdateIncidentResponse(string message)
    {
        public string Message { get; } = message;
    }
}
