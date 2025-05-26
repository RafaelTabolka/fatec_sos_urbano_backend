using SOSUrbano.Domain.Entities.IncidentEntity;

namespace SOSUrbano.Domain.Comands.ComandsIncident.IncidentComands.Create
{
    public class CreateIncidentResponse(Incident incident)
    {
        public Incident Incident { get; } = incident;
    }
}
