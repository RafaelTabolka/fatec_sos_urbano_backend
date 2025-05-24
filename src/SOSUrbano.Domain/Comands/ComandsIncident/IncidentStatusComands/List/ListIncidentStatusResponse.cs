using SOSUrbano.Domain.Entities.IncidentEntity;

namespace SOSUrbano.Domain.Comands.ComandsIncident.IncidentStatusComands.List
{
    public class ListIncidentStatusResponse(IEnumerable<IncidentStatus> incidentStatuses)
    {
        public IReadOnlyCollection<IncidentStatus> IncidentStatuses { get; } =
            incidentStatuses.ToList();
    }
}
