using SOSUrbano.Domain.Commands.CommandsAdmin.AdminReportsCommands.Get;

namespace SOSUrbano.Domain.Interfaces.Repositories.DashboardAdminRepository
{
    public interface IRepositoryDashboardAdmin
    {
        Task<GetAdminReportsResponse> GetInfosReport(GetAdminReportsRequest request);
    }
}
