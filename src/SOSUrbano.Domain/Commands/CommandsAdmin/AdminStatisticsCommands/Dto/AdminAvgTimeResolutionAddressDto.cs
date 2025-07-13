namespace SOSUrbano.Domain.Commands.CommandsAdmin.AdminStatisticsCommands.Dto
{
    public class AdminAvgTimeResolutionAddressDto
    {
        public string Address { get; set; } = string.Empty;

        public int AvgTimeInDays { get; set; }
    }
}
