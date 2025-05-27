using SOSUrbano.Domain.Entities.IncidentEntity;

namespace SOSUrbano.Domain.Comands.ComandsIncident.IncidentComands.Update
{
    public class UpdateIncidentResponse(Incident incident)
    {
        public Incident Incident { get; } = incident;
    }
}
