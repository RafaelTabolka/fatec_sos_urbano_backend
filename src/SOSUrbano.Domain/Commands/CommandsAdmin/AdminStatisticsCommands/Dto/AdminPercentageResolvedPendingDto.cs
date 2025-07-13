namespace SOSUrbano.Domain.Commands.CommandsAdmin.AdminStatisticsCommands.Dto
{
    public class AdminPercentageResolvedPendingDto
    {
        public string Address { get; set; } = string.Empty;

        public double PencentageResolved { get; set; }

        public double PercentagePending { get; set; }

        public int TotalIncidents { get; set; }
    }
}
