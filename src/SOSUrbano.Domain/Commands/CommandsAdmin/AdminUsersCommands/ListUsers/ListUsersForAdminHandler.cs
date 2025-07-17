using MediatR;
using SOSUrbano.Domain.Interfaces.Repositories.DashboardAdminRepository;

namespace SOSUrbano.Domain.Commands.CommandsAdmin.AdminUsersCommands.ListUsers
{
    internal class ListUsersForAdminHandler(IRepositoryDashboardAdmin repositoryDashboardAdmin) :
        IRequestHandler<ListUsersForAdminRequest, ListUsersForAdminResponse>
    {
        public async Task<ListUsersForAdminResponse> Handle(ListUsersForAdminRequest request, CancellationToken cancellationToken)
        {
            return await repositoryDashboardAdmin.ListUsersAsync(request);
        }
    }
}
