using MediatR;

namespace SOSUrbano.Domain.Commands.CommandsAdmin.AdminUsersCommands.ListUsers
{
    public class ListUsersForAdminRequest : IRequest<ListUsersForAdminResponse>
    {
        public string? Name { get; set; }

        public string? Status { get; set; } 

        public string? Comparative { get; set; }

        public int? Value { get; set; }

        public int? StartValueIsBetween { get; set; }

        public int? EndValueIsBetween { get; set; }
    }
}
