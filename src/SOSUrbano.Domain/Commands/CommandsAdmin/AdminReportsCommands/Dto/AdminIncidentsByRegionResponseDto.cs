namespace SOSUrbano.Domain.Commands.CommandsAdmin.AdminReportsCommands.Dto
{
    public class AdminIncidentsByRegionResponseDto
    {
        public string? Address { get; set; } = string.Empty;

        public int QtyIncidents { get; set; }
    }
}
