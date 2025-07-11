using SOSUrbano.Domain.Commands.CommandsAdmin.AdminInfosReportCommands.ListInfosReport;
using SOSUrbano.Domain.Commands.CommandsAdmin.AdminManageIncidentsCommands.ListManageIncidents;

namespace SOSUrbano.Domain.Interfaces.Repositories.DashboardAdminRepository
{
    public interface IRepositoryDashboardAdmin
    {
        Task<ListInfosReportResponse> GetInfosReportAsync(ListInfosReportRequest request);

        Task<ListManageIncidentsResponse> GetManageIncidentsAsync(ListManageIncidentsRequest request);
    }
}
