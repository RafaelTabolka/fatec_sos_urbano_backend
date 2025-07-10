using System.Text;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SOSUrbano.Domain.Commands.CommandsAdmin.AdminReportsCommands.Dto;
using SOSUrbano.Domain.Commands.CommandsAdmin.AdminReportsCommands.ListInfosReport;
using SOSUrbano.Domain.Interfaces.Repositories.DashboardAdminRepository;
using SOSUrbano.Infra.Data.Context;

namespace SOSUrbano.Infra.Data.Repository.DashboardRepository
{
    public class RepositoryDashboardAdmin(SOSUrbanoContext context) : IRepositoryDashboardAdmin
    {
        public async Task<ListInfosReportResponse> GetInfosReportAsync(ListInfosReportRequest request)
        {
            #region Card Quantity of Users
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
            #endregion

            #region Card Quantity of Incidents
            var sqlQtyIncidents = new StringBuilder();
            sqlQtyIncidents.Append(@"SELECT COUNT(i.Id) AS Value
                                      FROM tb_incidents AS i");
            var qtyIncidents = await context.Database
                .SqlQueryRaw<int>(sqlQtyIncidents.ToString())
                .FirstOrDefaultAsync();
            #endregion

            #region Card Quantity of Incidents Resolved
            var sqlQtyIncidentsResolved = new StringBuilder();
            sqlQtyIncidentsResolved.Append(@"SELECT COUNT(i.Id) AS Value
                                             FROM tb_incidents AS i
                                             INNER JOIN tb_incident_statuses AS ist
                                             ON (i.IncidentStatusId = ist.Id)
                                             WHERE ist.Name = 'Concluído'");
            var qtyIncidentsResolved = await context.Database
                .SqlQueryRaw<int>(sqlQtyIncidentsResolved.ToString())
                .FirstOrDefaultAsync();
            #endregion

            #region Card Average of Resolution Time in Days
            var sqlAvgResolutionTimeInDays = new StringBuilder();
            sqlAvgResolutionTimeInDays.Append(@"SELECT AVG(CAST(DATEDIFF(DAY, i.CreatedAt, i.UpdatedAt) AS FLOAT)) AS Value
                                                FROM tb_incidents AS i
                                                INNER JOIN tb_incident_statuses AS ist
                                                ON (i.IncidentStatusId = ist.Id)
                                                WHERE ist.Name = 'Concluído'");
            var avgResolutionTimeInDays = await context.Database
                .SqlQueryRaw<double?>(sqlAvgResolutionTimeInDays.ToString())
                .FirstOrDefaultAsync() ?? 0;
            #endregion

            #region Chart Incidents By Address
            var sqlIncidentsByAddress = new StringBuilder();
            sqlIncidentsByAddress.Append(@"SELECT i.Address, COUNT(i.Id) AS QtyIncidents 
                                           FROM tb_incidents AS i
                                           INNER JOIN tb_incident_statuses AS ist
                                           ON (i.IncidentStatusId = ist.Id)
                                           WHERE 1=1");

            var parametersIncidentByAddress = new List<SqlParameter>();

            sqlIncidentsByAddress.Append(MakeFiltersChart(request, parametersIncidentByAddress));

            //if (request.StartDate is not null)
            //    sqlIncidentsByAddress.Append($" AND i.CreatedAt >= '{request.StartDate:yyyy-MM-dd}'");

            //if (request.EndtDate is not null)
            //    sqlIncidentsByAddress.Append($" AND i.CreatedAt <= '{request.EndtDate:yyyy-MM-dd}'");

            //if (!string.IsNullOrWhiteSpace(request.Status))
            //    sqlIncidentsByAddress.Append($" AND ist.Name = '{request.Status}'");

            //if (!string.IsNullOrWhiteSpace(request.Address))
            //    sqlIncidentsByAddress.Append($" AND i.Address = '{request.Address}'");

            sqlIncidentsByAddress.Append(" GROUP BY i.Address");

            var incidentsByAddress = await context.Database
                .SqlQueryRaw<AdminIncidentsByRegionResponseDto>(
                sqlIncidentsByAddress.ToString(),
                parametersIncidentByAddress.ToArray())
                .ToListAsync();
            #endregion

            #region Chart Incidents by Statuses
            var sqlIncidentsByStatuses = new StringBuilder();
            sqlIncidentsByStatuses.Append(@"SELECT ist.Name AS Status, COUNT(i.Id) AS QtyIncidents
                                            FROM tb_incidents AS i
                                            INNER JOIN tb_incident_statuses AS ist
                                            ON (i.IncidentStatusId = ist.Id)
                                            WHERE 1=1");

            var parametersIncidentByStatuses = new List<SqlParameter>();

            sqlIncidentsByStatuses.Append(MakeFiltersChart(request, parametersIncidentByStatuses));

            //if (request.StartDate is not null)
            //    sqlIncidentsByStatuses.Append($" AND i.CreatedAt >= {request.StartDate}");

            //if (request.EndtDate is not null)
            //    sqlIncidentsByStatuses.Append($" AND i.CreatedAt <= {request.EndtDate}");

            //if (!string.IsNullOrWhiteSpace(request.Status))
            //    sqlIncidentsByStatuses.Append($" AND ist.Name = '{request.Status}'");

            //if (!string.IsNullOrWhiteSpace(request.Address))
            //    sqlIncidentsByStatuses.Append($" AND i.Address = '{request.Address}'");

            sqlIncidentsByStatuses.Append(" GROUP BY ist.Name");

            var incidentsByStatuses = await context.Database
                .SqlQueryRaw<AdminIncidentsByStatusesResponseDto>(
                sqlIncidentsByStatuses.ToString(),
                parametersIncidentByStatuses.ToArray())
                .ToListAsync();
            #endregion

            return new ListInfosReportResponse(
                qtyUsers, 
                qtyIncidents, 
                qtyIncidentsResolved, 
                avgResolutionTimeInDays,
                incidentsByAddress,
                incidentsByStatuses);    
        }

        #region Function of Filters for Charts
        internal StringBuilder MakeFiltersChart(ListInfosReportRequest request, List<SqlParameter> parameters)
        {
            var filters = new StringBuilder();
            
            if (request.StartDate is not null)
            {
                filters.Append($" AND i.CreatedAt >= @startDate");
                parameters.Add(new SqlParameter("@startDate", request.StartDate));
            }
            if (request.EndtDate is not null)
            {
                filters.Append($" AND i.CreatedAt <= @endDate");
                parameters.Add(new SqlParameter("@endDate", request.EndtDate));
            }

            if (!string.IsNullOrWhiteSpace(request.Status))
            {
                filters.Append($" AND ist.Name = @status");
                parameters.Add(new SqlParameter("@status", request.Status));
            }

            if (!string.IsNullOrWhiteSpace(request.Address))
            {
                filters.Append($" AND i.Address = @address");
                parameters.Add(new SqlParameter("@address", request.Address));
            }

            return filters;
        }
        #endregion
    }
}
