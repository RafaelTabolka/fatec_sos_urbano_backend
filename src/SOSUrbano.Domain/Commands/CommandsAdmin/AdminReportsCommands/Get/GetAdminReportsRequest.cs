using MediatR;

namespace SOSUrbano.Domain.Commands.CommandsAdmin.AdminReportsCommands.Get
{
    public class GetAdminReportsRequest : IRequest<GetAdminReportsResponse>
    {
        public DateTime? StartDate { get; set; }

        public DateTime? EndtDate { get; set; }

        public string? Status { get; set; } = string.Empty;

        public string? Address { get; set; } = string.Empty;
    }
}
