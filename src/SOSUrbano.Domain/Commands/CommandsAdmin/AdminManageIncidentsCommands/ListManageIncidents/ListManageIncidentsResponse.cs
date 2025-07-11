using SOSUrbano.Domain.Commands.CommandsAdmin.AdminManageIncidentsCommands.Dto;

namespace SOSUrbano.Domain.Commands.CommandsAdmin.AdminManageIncidentsCommands.ListManageIncidents
{
    public class ListManageIncidentsResponse(List<AdminManageIncidentsDto> adminManageIncidentsDtos)
    {
        public List<AdminManageIncidentsDto> AdminManageIncidentsDtos { get; } = adminManageIncidentsDtos;
    }
}
