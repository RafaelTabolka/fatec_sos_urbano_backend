using SOSUrbano.Domain.Commands.CommandsIncident.IncidentCommands.Dto;

namespace SOSUrbano.Domain.Commands.CommandsIncident.IncidentCommands.Create
{
    public class CreateIncidentResponse(DtoIncidentResponse dtoIncidentResponse)
    {
        public DtoIncidentResponse DtoIncidentResponse { get; } = dtoIncidentResponse;
    }
}
