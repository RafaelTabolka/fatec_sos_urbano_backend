using SOSUrbano.Domain.Commands.CommandsAdmin.AdminReportsCommands.ListInfosReport;

namespace SOSUrbano.Domain.Interfaces.Repositories.DashboardAdminRepository
{
    public interface IRepositoryDashboardAdmin
    {
        Task<ListInfosReportResponse> GetInfosReportAsync(ListInfosReportRequest request);
    }
}
