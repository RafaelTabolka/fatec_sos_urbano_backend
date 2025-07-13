using MediatR;
using SOSUrbano.Domain.Interfaces.Repositories.DashboardAdminRepository;


namespace SOSUrbano.Domain.Commands.CommandsAdmin.AdminInfosReportCommands.ListInfosReport
{
    internal class ListInfosReportHandler(IRepositoryDashboardAdmin repositoryDashboard) :
        IRequestHandler<ListInfosReportRequest, ListInfosReportResponse>
    {
        public async Task<ListInfosReportResponse> Handle
            (ListInfosReportRequest request, CancellationToken cancellationToken)
        {
            return await repositoryDashboard.ListInfosReportAsync(request);
        }
    }
}
