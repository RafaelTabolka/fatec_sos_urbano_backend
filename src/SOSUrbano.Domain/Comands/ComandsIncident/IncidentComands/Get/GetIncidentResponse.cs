using SOSUrbano.Domain.Entities.IncidentEntity;

namespace SOSUrbano.Domain.Comands.ComandsIncident.IncidentComands.Get
{
    public class GetIncidentResponse(Incident incident)
    {
        public Incident Incident { get; } = incident;
    }
}
