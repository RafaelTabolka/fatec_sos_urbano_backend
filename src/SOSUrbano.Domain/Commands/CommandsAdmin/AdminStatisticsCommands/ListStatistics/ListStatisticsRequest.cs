using MediatR;

namespace SOSUrbano.Domain.Commands.CommandsAdmin.AdminStatisticsCommands.ListStatistics
{
    public class ListStatisticsRequest : IRequest<ListStatisticsResponse>
    {
        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public int? StartHour { get; set; }

        public int? EndHour { get; set; }

        public string? Address { get; set; }
    }
}
