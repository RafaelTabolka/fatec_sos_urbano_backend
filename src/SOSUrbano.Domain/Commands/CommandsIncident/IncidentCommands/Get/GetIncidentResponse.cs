using SOSUrbano.Domain.Commands.CommandsIncident.IncidentCommands.Dto;

namespace SOSUrbano.Domain.Commands.CommandsIncident.IncidentCommands.Get
{
    public class GetIncidentResponse(DtoIncidentResponse incident)
    {
        public DtoIncidentResponse Incident { get; } = incident;
    }
}
