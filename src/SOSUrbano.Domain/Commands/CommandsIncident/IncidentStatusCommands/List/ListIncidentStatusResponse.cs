using SOSUrbano.Domain.Entities.IncidentEntity;

namespace SOSUrbano.Domain.Commands.CommandsIncident.IncidentStatusCommands.List
{
    public class ListIncidentStatusResponse(IEnumerable<IncidentStatus> incidentStatuses)
    {
        public IReadOnlyCollection<IncidentStatus> IncidentStatuses { get; } =
            incidentStatuses.ToList();
    }
}
