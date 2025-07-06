using System.Text;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SOSUrbano.Domain.Commands.CommandsAdmin.AdminReportsCommands.Dto;
using SOSUrbano.Domain.Commands.CommandsAdmin.AdminReportsCommands.Get;
using SOSUrbano.Domain.Interfaces.Repositories.DashboardAdminRepository;
using SOSUrbano.Infra.Data.Context;

namespace SOSUrbano.Infra.Data.Repository.DashboardRepository
{
    public class RepositoryDashboardAdmin(SOSUrbanoContext context) : IRepositoryDashboardAdmin
    {
        public async Task<GetAdminReportsResponse> GetInfosReport(GetAdminReportsRequest request)
        {
            var sqlQtyUsers = new StringBuilder();
            sqlQtyUsers.Append(@"SELECT COUNT(u.Id) AS Value
                                     FROM tb_users AS u
                                     INNER JOIN tb_user_statuses AS us
                                     ON (u.UserStatusId = us.Id)
                                     INNER JOIN tb_user_types AS ut
                                     ON (u.UserTypeId = ut.Id)
                                     WHERE us.Name = 'ativo' AND ut.Name = 'comum'");
            var qtyUsers = await context.Database
                .SqlQueryRaw<int>(sqlQtyUsers.ToString())
                .FirstOrDefaultAsync();


            var sqlQtyIncidents = new StringBuilder();
            sqlQtyIncidents.Append(@"SELECT COUNT(i.Id) AS Value
                                      FROM tb_incidents AS i");
            var qtyIncidents = await context.Database
                .SqlQueryRaw<int>(sqlQtyIncidents.ToString())
                .FirstOrDefaultAsync();


            var sqlQtyIncidentsResolved = new StringBuilder();
            sqlQtyIncidentsResolved.Append(@"SELECT COUNT(i.Id) AS Value
                                             FROM tb_incidents AS i
                                             INNER JOIN tb_incident_statuses AS ist
                                             ON (i.IncidentStatusId = ist.Id)
                                             WHERE ist.Name = 'Concluído'");
            var qtyIncidentsResolved = await context.Database
                .SqlQueryRaw<int>(sqlQtyIncidentsResolved.ToString())
                .FirstOrDefaultAsync();


            var sqlAvgResolutionTimeInDays = new StringBuilder();
            sqlAvgResolutionTimeInDays.Append(@"SELECT AVG(CAST(DATEDIFF(DAY, i.CreatedAt, i.UpdatedAt) AS FLOAT)) AS Value
                                                FROM tb_incidents AS i
                                                INNER JOIN tb_incident_statuses AS ist
                                                ON (i.IncidentStatusId = ist.Id)
                                                WHERE ist.Name = 'Concluído'");
            var avgResolutionTimeInDays = await context.Database
                .SqlQueryRaw<double?>(sqlAvgResolutionTimeInDays.ToString())
                .FirstOrDefaultAsync() ?? 0;


            var sqlIncidentsByAddress = new StringBuilder();
            var parameters = new List<SqlParameter>();
            
            sqlIncidentsByAddress.Append(@"SELECT i.Address, COUNT(i.Id) AS QtyIncidents 
                                           FROM tb_incidents AS i
                                           INNER JOIN tb_incident_statuses AS ist
                                           ON (i.IncidentStatusId = ist.Id)
                                           WHERE 1=1");

            if (request.StartDate is not null)
            {
                sqlIncidentsByAddress.Append(" AND i.CreateAt >= @startDate");
                parameters.Add(new SqlParameter("@startDate", request.StartDate));
            }

            if (request.EndtDate is not null)
            {
                sqlIncidentsByAddress.Append(" AND i.CreateAt <= @endDate");
                parameters.Add(new SqlParameter("@endDate", request.EndtDate));
            }

            if (!string.IsNullOrWhiteSpace(request.Status))
            {
                sqlIncidentsByAddress.Append(" AND ist.Name = @status");
                parameters.Add(new SqlParameter("@status", request.Status));
            }

            if (!string.IsNullOrWhiteSpace(request.Address))
            {
                sqlIncidentsByAddress.Append(" AND i.Address = @address");
                parameters.Add(new SqlParameter("@address", request.Address));
            }


            sqlIncidentsByAddress.Append(" GROUP BY i.Address");

            var incidentsByAddress = await context.Database
                .SqlQueryRaw<AdminIncidentsByRegionResponseDto>(sqlIncidentsByAddress.ToString(), parameters.ToArray())
                .ToListAsync();

            return new GetAdminReportsResponse(
                qtyUsers, 
                qtyIncidents, 
                qtyIncidentsResolved, 
                avgResolutionTimeInDays,
                incidentsByAddress);
        }
    }
}
