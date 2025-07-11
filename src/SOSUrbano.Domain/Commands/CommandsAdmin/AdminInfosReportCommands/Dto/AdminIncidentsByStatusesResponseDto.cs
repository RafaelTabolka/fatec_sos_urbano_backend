namespace SOSUrbano.Domain.Commands.CommandsAdmin.AdminInfosReportCommands.Dto
{
    public class AdminIncidentsByStatusesResponseDto
    {
        public string? Status { get; set; } = string.Empty;

        public int QtyIncidents { get; set; }
    }
}
