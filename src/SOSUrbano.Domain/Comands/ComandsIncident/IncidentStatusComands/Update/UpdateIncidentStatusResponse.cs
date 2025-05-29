using SOSUrbano.Domain.Entities.IncidentEntity;

namespace SOSUrbano.Domain.Comands.ComandsIncident.IncidentStatusComands.Update
{
    public class UpdateIncidentStatusResponse(string message)
    {
        public string Message { get; } = message;
    }
}
