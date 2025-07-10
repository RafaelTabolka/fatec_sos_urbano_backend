using MediatR;
using SOSUrbano.Domain.Interfaces.Repositories.DashboardAdminRepository;


namespace SOSUrbano.Domain.Commands.CommandsAdmin.AdminReportsCommands.ListInfosReport
{
    internal class ListInfosReportHandler(IRepositoryDashboardAdmin repositoryDashboard) :
        IRequestHandler<ListInfosReportRequest, ListInfosReportResponse>
    {
        public Task<ListInfosReportResponse> Handle
            (ListInfosReportRequest request, CancellationToken cancellationToken)
        {
            return repositoryDashboard.GetInfosReportAsync(request);
        }
    }
}
