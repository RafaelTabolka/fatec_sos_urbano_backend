using SOSUrbano.Domain.Commands.CommandsAdmin.AdminInfosReportCommands.ListInfosReport;
using SOSUrbano.Domain.Commands.CommandsAdmin.AdminManageIncidentsCommands.ListManageIncidents;
using SOSUrbano.Domain.Commands.CommandsAdmin.AdminStatisticsCommands.ListStatistics;
using SOSUrbano.Domain.Commands.CommandsAdmin.AdminUsersCommands.ListUsers;

namespace SOSUrbano.Domain.Interfaces.Repositories.DashboardAdminRepository
{
    public interface IRepositoryDashboardAdmin
    {
        Task<ListInfosReportResponse> ListInfosReportAsync(ListInfosReportRequest request);

        Task<ListManageIncidentsResponse> ListManageIncidentsAsync(ListManageIncidentsRequest request);

        Task<ListStatisticsResponse> ListStatisticsAsync(ListStatisticsRequest request);

        Task<ListUsersForAdminResponse> ListUsersAsync(ListUsersForAdminRequest request);
    }
}
