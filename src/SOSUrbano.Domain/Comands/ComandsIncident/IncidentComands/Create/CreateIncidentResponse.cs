using SOSUrbano.Domain.Comands.ComandsIncident.IncidentComands.Dto;

namespace SOSUrbano.Domain.Comands.ComandsIncident.IncidentComands.Create
{
    public class CreateIncidentResponse(DtoIncidentResponse dtoIncidentResponse)
    {
        public DtoIncidentResponse DtoIncidentResponse { get; } = dtoIncidentResponse;
    }
}
