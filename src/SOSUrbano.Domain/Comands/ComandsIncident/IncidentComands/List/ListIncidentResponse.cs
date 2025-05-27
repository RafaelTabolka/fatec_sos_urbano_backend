using SOSUrbano.Domain.Entities.IncidentEntity;

namespace SOSUrbano.Domain.Comands.ComandsIncident.IncidentComands.List
{
    public class ListIncidentResponse(IEnumerable<Incident> incidents)
    {
        public IReadOnlyCollection<Incident> Incidents { get; } =
            incidents.ToList();
    }
}
