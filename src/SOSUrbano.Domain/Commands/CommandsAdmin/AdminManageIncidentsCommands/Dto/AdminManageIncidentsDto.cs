namespace SOSUrbano.Domain.Commands.CommandsAdmin.AdminManageIncidentsCommands.Dto
{
    public class AdminManageIncidentsDto
    {
        public string UserName { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string Status { get; set; } = string.Empty;

        public DateTime DateIncident { get; set; }

        public DateTime? DateResolution { get; set; }

        public string Address { get; set; } = string.Empty;

        public string Institution { get; set; } = string.Empty;
    }
}
