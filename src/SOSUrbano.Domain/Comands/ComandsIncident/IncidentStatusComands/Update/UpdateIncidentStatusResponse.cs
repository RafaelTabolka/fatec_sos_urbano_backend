using SOSUrbano.Domain.Entities.IncidentEntity;

namespace SOSUrbano.Domain.Comands.ComandsIncident.IncidentStatusComands.Update
{
    public class UpdateIncidentStatusResponse
        (IncidentStatus incidentStatus)
    {
        public IncidentStatus IncidentStatus { get; } = incidentStatus;
    }
}
