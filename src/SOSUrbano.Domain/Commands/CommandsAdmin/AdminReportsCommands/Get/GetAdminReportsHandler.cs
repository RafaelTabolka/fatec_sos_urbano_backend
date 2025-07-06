using MediatR;
using SOSUrbano.Domain.Interfaces.Repositories.DashboardAdminRepository;


namespace SOSUrbano.Domain.Commands.CommandsAdmin.AdminReportsCommands.Get
{
    internal class GetAdminReportsHandler(IRepositoryDashboardAdmin repositoryDashboard) :
        IRequestHandler<GetAdminReportsRequest, GetAdminReportsResponse>
    {
        public Task<GetAdminReportsResponse> Handle
            (GetAdminReportsRequest request, CancellationToken cancellationToken)
        {
            return repositoryDashboard.GetInfosReport(request);
        }
    }
}
