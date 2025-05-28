using SOSUrbano.Domain.Comands.ComandsIncident.IncidentComands.Dto;
using SOSUrbano.Domain.Entities.IncidentEntity;

namespace SOSUrbano.Domain.Comands.ComandsIncident.IncidentComands.Get
{
    public class GetIncidentResponse(DtoIncidentResponse incident)
    {
        public DtoIncidentResponse Incident { get; } = incident;
    }
}
