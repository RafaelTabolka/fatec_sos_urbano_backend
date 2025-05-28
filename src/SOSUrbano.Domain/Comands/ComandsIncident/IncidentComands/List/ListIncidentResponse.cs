using SOSUrbano.Domain.Comands.ComandsIncident.IncidentComands.Dto;
using SOSUrbano.Domain.Entities.IncidentEntity;

namespace SOSUrbano.Domain.Comands.ComandsIncident.IncidentComands.List
{
    public class ListIncidentResponse(IEnumerable<DtoIncidentResponse> incidents)
    {
        public IReadOnlyCollection<DtoIncidentResponse> Incidents { get; } =
            incidents.ToList();
    }
}
