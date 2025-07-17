namespace SOSUrbano.Domain.Commands.CommandsAdmin.AdminUsersCommands.Dto
{
    public class AdminUsersDto
    {
        public string Name { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public int QtyIncidents { get; set; }

        public string Status { get; set; } = string.Empty;

        public string PhoneNumber { get; set; } = string.Empty;
    }
}
