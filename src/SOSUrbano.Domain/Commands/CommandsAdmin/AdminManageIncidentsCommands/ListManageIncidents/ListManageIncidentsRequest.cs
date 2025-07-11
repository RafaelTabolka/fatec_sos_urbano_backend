using MediatR;

namespace SOSUrbano.Domain.Commands.CommandsAdmin.AdminManageIncidentsCommands.ListManageIncidents
{
    public class ListManageIncidentsRequest : IRequest<ListManageIncidentsResponse>
    {
        public string? UserName { get; set; }

        public string? Description { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public string? Status { get; set; }
        
        public string? Institution { get; set; }

        public string? Address { get; set; }
    }
}
