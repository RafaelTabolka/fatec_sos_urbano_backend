using MediatR;
using SOSUrbano.Domain.Interfaces.Repositories.DashboardAdminRepository;

namespace SOSUrbano.Domain.Commands.CommandsAdmin.AdminManageIncidentsCommands.ListManageIncidents
{
    public class ListManageIncidentsHandler(IRepositoryDashboardAdmin repositoryDashboardAdmin) :
        IRequestHandler<ListManageIncidentsRequest, ListManageIncidentsResponse>
    {
        public async Task<ListManageIncidentsResponse> Handle
            (ListManageIncidentsRequest request, CancellationToken cancellationToken)
        {
            return await repositoryDashboardAdmin.ListManageIncidentsAsync(request);
        }
    }
}
