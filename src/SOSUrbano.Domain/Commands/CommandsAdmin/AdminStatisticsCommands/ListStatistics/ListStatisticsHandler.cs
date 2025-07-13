using MediatR;
using SOSUrbano.Domain.Interfaces.Repositories.DashboardAdminRepository;

namespace SOSUrbano.Domain.Commands.CommandsAdmin.AdminStatisticsCommands.ListStatistics
{
    public class ListStatisticsHandler(
        IRepositoryDashboardAdmin repositoryDashboardAdmin) :
        IRequestHandler<ListStatisticsRequest, ListStatisticsResponse>
    {
        public async Task<ListStatisticsResponse> Handle(
            ListStatisticsRequest request, CancellationToken cancellationToken)
        {
            return await repositoryDashboardAdmin.ListStatisticsAsync(request);
        }
    }
}
