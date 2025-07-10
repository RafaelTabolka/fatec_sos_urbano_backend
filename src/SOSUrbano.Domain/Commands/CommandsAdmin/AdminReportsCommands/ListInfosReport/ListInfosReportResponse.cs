using SOSUrbano.Domain.Commands.CommandsAdmin.AdminReportsCommands.Dto;

namespace SOSUrbano.Domain.Commands.CommandsAdmin.AdminReportsCommands.ListInfosReport
{
    public class ListInfosReportResponse(
        int qtyUsers, 
        int qtyIncidents, 
        int qtyIncidentsResolved, 
        double avgResolutionTimeInDays,
        List<AdminIncidentsByRegionResponseDto> adminIncidentsByRegionDtos,
        List<AdminIncidentsByStatusesResponseDto> adminIncidentsByStatusesDtos)
    {
        public int QtyUsers { get; set; } = qtyUsers;

        public int QtyIncidents { get; set; } = qtyIncidents;

        public int QtyIncidentsResolved { get; set; } = qtyIncidentsResolved;

        public double AvgResolutionTimeInDays { get; set; } = avgResolutionTimeInDays;

        public List<AdminIncidentsByRegionResponseDto> AdminIncidentsByRegionsDto { get; set; } = adminIncidentsByRegionDtos;

        public List<AdminIncidentsByStatusesResponseDto> AdminIncidentsByStatusesDto { get; set; } = adminIncidentsByStatusesDtos;
    }
}
    