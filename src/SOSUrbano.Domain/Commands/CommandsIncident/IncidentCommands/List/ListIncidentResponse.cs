using SOSUrbano.Domain.Commands.CommandsIncident.IncidentCommands.Dto;
using SOSUrbano.Domain.Entities.IncidentEntity;

namespace SOSUrbano.Domain.Commands.CommandsIncident.IncidentCommands.List
{
    public class ListIncidentResponse(IEnumerable<DtoIncidentResponse> incidents)
    {
        public IReadOnlyCollection<DtoIncidentResponse> Incidents { get; } =
            incidents.ToList();
    }
}
