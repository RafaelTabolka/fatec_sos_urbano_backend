using SOSUrbano.Domain.Commands.CommandsAdmin.AdminReportsCommands.Dto;

namespace SOSUrbano.Domain.Commands.CommandsAdmin.AdminReportsCommands.Get
{
    public class GetAdminReportsResponse(
        int qtyUsers, 
        int qtyIncidents, 
        int qtyIncidentsResolved, 
        double avgResolutionTimeInDays,
        List<AdminIncidentsByRegionResponseDto> adminIncidentsByRegionDto)
    {
        public int QtyUsers { get; set; } = qtyUsers;

        public int QtyIncidents { get; set; } = qtyIncidents;

        public int QtyIncidentsResolved { get; set; } = qtyIncidentsResolved;

        public double AvgResolutionTimeInDays { get; set; } = avgResolutionTimeInDays;

        public List<AdminIncidentsByRegionResponseDto> AdminIncidentsByRegionsDto { get; set; } = adminIncidentsByRegionDto;
    }
}
    