namespace SOSUrbano.Domain.Commands.CommandsAdmin.AdminInfosReportCommands.Dto
{
    public class AdminIncidentsByRegionResponseDto
    {
        public string? Address { get; set; } = string.Empty;

        public int QtyIncidents { get; set; }
    }
}
