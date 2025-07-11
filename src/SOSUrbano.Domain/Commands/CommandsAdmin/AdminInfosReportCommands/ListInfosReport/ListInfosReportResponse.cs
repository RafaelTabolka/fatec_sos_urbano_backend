using SOSUrbano.Domain.Commands.CommandsAdmin.AdminInfosReportCommands.Dto;

namespace SOSUrbano.Domain.Commands.CommandsAdmin.AdminInfosReportCommands.ListInfosReport
{
    public class ListInfosReportResponse(
        int qtyUsers, 
        int qtyIncidents, 
        int qtyIncidentsResolved, 
        double avgResolutionTimeInDays,
        List<AdminIncidentsByRegionResponseDto> adminIncidentsByRegionDtos,
        List<AdminIncidentsByStatusesResponseDto> adminIncidentsByStatusesDtos)
    {
        public int QtyUsers { get; } = qtyUsers;

        public int QtyIncidents { get; } = qtyIncidents;

        public int QtyIncidentsResolved { get; } = qtyIncidentsResolved;

        public double AvgResolutionTimeInDays { get; } = avgResolutionTimeInDays;

        public List<AdminIncidentsByRegionResponseDto> AdminIncidentsByRegionsDto { get; } = adminIncidentsByRegionDtos;

        public List<AdminIncidentsByStatusesResponseDto> AdminIncidentsByStatusesDto { get; } = adminIncidentsByStatusesDtos;
    }
}
    