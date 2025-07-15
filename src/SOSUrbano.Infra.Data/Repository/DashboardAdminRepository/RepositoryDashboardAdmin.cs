using System.Text;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SOSUrbano.Domain.Commands.CommandsAdmin.AdminInfosReportCommands.Dto;
using SOSUrbano.Domain.Commands.CommandsAdmin.AdminInfosReportCommands.ListInfosReport;
using SOSUrbano.Domain.Commands.CommandsAdmin.AdminManageIncidentsCommands.Dto;
using SOSUrbano.Domain.Commands.CommandsAdmin.AdminManageIncidentsCommands.ListManageIncidents;
using SOSUrbano.Domain.Commands.CommandsAdmin.AdminStatisticsCommands.Dto;
using SOSUrbano.Domain.Commands.CommandsAdmin.AdminStatisticsCommands.ListStatistics;
using SOSUrbano.Domain.Interfaces.Repositories.DashboardAdminRepository;
using SOSUrbano.Infra.Data.Context;

namespace SOSUrbano.Infra.Data.Repository.DashboardRepository
{
    public class RepositoryDashboardAdmin(SOSUrbanoContext context) : IRepositoryDashboardAdmin
    {
        public async Task<ListInfosReportResponse> ListInfosReportAsync(ListInfosReportRequest request)
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

            #region Chart Incidents by Address
            var sqlIncidentsByAddress = new StringBuilder();
            sqlIncidentsByAddress.Append(@"SELECT i.Address, COUNT(i.Id) AS QtyIncidents 
                                           FROM tb_incidents AS i
                                           INNER JOIN tb_incident_statuses AS ist
                                           ON (i.IncidentStatusId = ist.Id)
                                           WHERE 1=1");

            List<SqlParameter>parametersIncidentByAddress = [];

            sqlIncidentsByAddress.Append(MakeFiltersChartsInfosReport(request, parametersIncidentByAddress));

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

             List<SqlParameter> parametersIncidentByStatuses = [];

            sqlIncidentsByStatuses.Append(MakeFiltersChartsInfosReport(request, parametersIncidentByStatuses));

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

        #region Function for Page Admin/Report
        internal StringBuilder MakeFiltersChartsInfosReport(ListInfosReportRequest request, List<SqlParameter> parameters)
        {
            var filter = new StringBuilder();
            
            if (request.StartDate is not null)
            {
                filter.Append($" AND i.CreatedAt >= @startDate");
                parameters.Add(new SqlParameter("@startDate", request.StartDate));
            }
            if (request.EndtDate is not null)
            {
                filter.Append($" AND i.CreatedAt <= @endDate");
                parameters.Add(new SqlParameter("@endDate", request.EndtDate));
            }

            if (!string.IsNullOrWhiteSpace(request.Status))
            {
                filter.Append($" AND ist.Name = @status");
                parameters.Add(new SqlParameter("@status", request.Status));
            }

            if (!string.IsNullOrWhiteSpace(request.Address))
            {
                filter.Append($" AND i.Address = @address");
                parameters.Add(new SqlParameter("@address", request.Address));
            }

            return filter;
        }
        #endregion
        
        public async Task<ListManageIncidentsResponse> ListManageIncidentsAsync(ListManageIncidentsRequest request)
        {
            #region Table Incidents
            var sqlManageIncidents = new StringBuilder();

            sqlManageIncidents.Append(@"SELECT 
	                                        u.Name AS UserName, 
	                                        i.Description AS Description, 
	                                        ist.Name AS Status, 
	                                        i.CreatedAt AS DateIncident,
	                                        IIF(ist.Name = 'Concluído', i.UpdatedAt, null) AS DateResolution,
	                                        i.Address,
	                                        ins.Name AS Institution
                                        FROM tb_users AS u
                                        INNER JOIN tb_incidents AS i
                                        ON (i.UserId = u.Id)
                                        INNER JOIN tb_incident_statuses AS ist
                                        ON (ist.Id = i.IncidentStatusId)
                                        INNER JOIN tb_institutions AS ins
                                        ON (ins.Id = i.InstitutionId)
                                        WHERE 1=1");

            var parameters = new List<SqlParameter>();

            if (!string.IsNullOrWhiteSpace(request.UserName))
            {
                sqlManageIncidents.Append(" AND u.Name = @userName");
                parameters.Add(new SqlParameter("@userName", request.UserName));
            }

            if (!string.IsNullOrWhiteSpace(request.Description))
            {
                sqlManageIncidents.Append(" AND i.Description = @description");
                parameters.Add(new SqlParameter("@description", request.Description));
            }

            if (request.StartDate is not null)
            {
                sqlManageIncidents.Append(" AND i.CreatedAt >= @startDate");
                parameters.Add(new SqlParameter("@startDate", request.StartDate));
            }

            if (request.EndDate is not null)
            {
                sqlManageIncidents.Append(" AND i.CreatedAt <= @endDate");
                parameters.Add(new SqlParameter("@endDate", request.EndDate));
            }

            if (!string.IsNullOrWhiteSpace(request.Status))
            {
                sqlManageIncidents.Append(" AND ist.Name = @status");
                parameters.Add(new SqlParameter("@status", request.Status));
            }

            if (!string.IsNullOrWhiteSpace(request.Institution))
            {
                sqlManageIncidents.Append(" AND ins.Name = @institution");
                parameters.Add(new SqlParameter("@institution", request.Institution));
            }

            if (!string.IsNullOrWhiteSpace(request.Address))
            {
                sqlManageIncidents.Append(" AND i.Address = @address");
                parameters.Add(new SqlParameter("@address", request.Address));
            }

            var manageIncidents = await context.Database.SqlQueryRaw<AdminManageIncidentsDto>(
                sqlManageIncidents.ToString(),
                parameters.ToArray())
                .ToListAsync();
            #endregion

            return new ListManageIncidentsResponse(manageIncidents);
        }

        public async Task<ListStatisticsResponse> ListStatisticsAsync(ListStatisticsRequest request)
        {
            #region Chart Incidents by Our of Day
            var sqlIncidentsByHourOfDay = new StringBuilder();

            sqlIncidentsByHourOfDay.Append(@"SELECT h.HourOfDay, COUNT(i.Id) AS QtyIncidents
		                                     FROM 
		                                     (
			                                    SELECT 0 AS HourOfDay 
			                                    UNION ALL SELECT 1
			                                    UNION ALL SELECT 2 
			                                    UNION ALL SELECT 3
			                                    UNION ALL SELECT 4
			                                    UNION ALL SELECT 5
			                                    UNION ALL SELECT 6
			                                    UNION ALL SELECT 7
			                                    UNION ALL SELECT 8 
			                                    UNION ALL SELECT 9
			                                    UNION ALL SELECT 10
			                                    UNION ALL SELECT 11
			                                    UNION ALL SELECT 12
			                                    UNION ALL SELECT 13
			                                    UNION ALL SELECT 14
			                                    UNION ALL SELECT 15
			                                    UNION ALL SELECT 16
			                                    UNION ALL SELECT 17
			                                    UNION ALL SELECT 18
			                                    UNION ALL SELECT 19
			                                    UNION ALL SELECT 20
			                                    UNION ALL SELECT 21
			                                    UNION ALL SELECT 22
			                                    UNION ALL SELECT 23
		                                     ) AS h
	                                     LEFT JOIN tb_incidents AS i
	                                     ON (DATEPART(HOUR, i.CreatedAt) = h.HourOfDay)
                                         WHERE 1=1");

            List<SqlParameter> parametersIncidentsByHour = [];
            
            sqlIncidentsByHourOfDay.Append(MakeDateAddressFilters(request, parametersIncidentsByHour));

            sqlIncidentsByHourOfDay.Append(" GROUP BY h.HourOfDay");

            if (request.StartHour is not null || request.EndHour is not null)
            {
                sqlIncidentsByHourOfDay.Append(" HAVING 1=1");
                sqlIncidentsByHourOfDay.Append(MakeHourFilters(request, parametersIncidentsByHour, "h.HourOfDay"));
                sqlIncidentsByHourOfDay.Append(" AND COUNT(i.Id) > 0");
            }

            var incidentsByHourOfDay = await context.Database.SqlQueryRaw<AdminsIncidentsByHourOfDayDto>(
                sqlIncidentsByHourOfDay.ToString(),
                parametersIncidentsByHour.ToArray())
                .ToListAsync();
            #endregion

            #region Heat Map
            var sqlHeatMap = new StringBuilder();
            List<SqlParameter> parametersHeatMap = [];

            sqlHeatMap.Append(@"SELECT 
		                            i.LatLocalization, 
		                            i.LongLocalization,
		                            ROUND(
			                            CAST(COUNT(i.Id) AS FLOAT) /
			                            (
				                               SELECT COUNT(i.Id)
				                            FROM tb_incidents AS i
                                            WHERE 1=1");

            sqlHeatMap.Append(MakeDateAddressFilters(request, parametersHeatMap));

            sqlHeatMap.Append(MakeHourFilters(request, parametersHeatMap, "DATEPART(HOUR, i.CreatedAt)"));

            sqlHeatMap.Append("), 3) AS PercentageTotalIncidents FROM tb_incidents AS i WHERE 1=1");

            sqlHeatMap.Append(MakeDateAddressFilters(request, parametersHeatMap));

            sqlHeatMap.Append(MakeHourFilters(request, parametersHeatMap, "DATEPART(HOUR, i.CreatedAt)"));

            sqlHeatMap.Append(" GROUP BY i.LatLocalization, i.LongLocalization");

            var heatMap = await context.Database.SqlQueryRaw<AdminHeatMapDto>(
                sqlHeatMap.ToString(),
                parametersHeatMap.ToArray())
                .ToListAsync();
            #endregion

            #region Chart Avg Time of Resolution by Address
            var sqlAvgTimeOfResolutionByAddress = new StringBuilder();

            sqlAvgTimeOfResolutionByAddress.Append(@"SELECT i.Address, AVG(DATEDIFF(DAY, i.CreatedAt, i.UpdatedAt)) AS AvgTimeOfResolution
	                                        FROM tb_incidents AS i
	                                        INNER JOIN tb_incident_statuses AS ist
	                                        ON (i.IncidentStatusId = ist.Id)
	                                        WHERE ist.Name = 'Concluído'");

            List<SqlParameter> parametersAvgTimeByAddress = [];

            sqlAvgTimeOfResolutionByAddress.Append(MakeDateAddressFilters(request, parametersAvgTimeByAddress));

            sqlAvgTimeOfResolutionByAddress.Append(
                MakeHourFilters(request, parametersAvgTimeByAddress, "DATEPART(HOUR, i.CreatedAt)"));

            sqlAvgTimeOfResolutionByAddress.Append(" GROUP BY i.Address");

            var avgTimeOfResolutionByAddress = await context.Database.SqlQueryRaw<AdminAvgTimeResolutionAddressDto>(
                sqlAvgTimeOfResolutionByAddress.ToString(),
                parametersAvgTimeByAddress.ToArray())
                .ToListAsync();
            #endregion

            var sqlPercentageResolvedPending = new StringBuilder();

            sqlPercentageResolvedPending.Append(@"SELECT 
		                                            i.Address,
		                                            ROUND(
			                                            CAST(
				                                            SUM(
					                                            CASE WHEN ist.Name = 'Concluído' THEN 1 ELSE 0 END) AS FLOAT), 3) /
		                                            COUNT(i.Id) * 100 AS PercentageResolved,
		                                            ROUND(
			                                            CAST(
				                                            SUM(
					                                            CASE WHEN ist.Name <> 'Concluído' THEN 1 ELSE 0 END) AS FLOAT), 3) /
		                                            COUNT(i.Id) * 100 AS PercentagePending,
		                                            COUNT(i.Id) AS TotalIncidents
	                                            FROM tb_incidents AS i
	                                            INNER JOIN tb_incident_statuses AS ist
	                                            ON (i.IncidentStatusId = ist.Id)
	                                            WHERE 1=1");

            List<SqlParameter> parametersPercentageResolvedPending = [];

            sqlPercentageResolvedPending.Append(
                MakeDateAddressFilters(request, parametersPercentageResolvedPending));

            sqlPercentageResolvedPending.Append(
                MakeHourFilters(request, parametersPercentageResolvedPending, "DATEPART(HOUR, i.CreatedAt)"));

            sqlPercentageResolvedPending.Append(" GROUP BY i.Address");

            var percentageResolvedPending = await context.Database.SqlQueryRaw<AdminPercentageResolvedPendingDto>(
                sqlPercentageResolvedPending.ToString(),
                parametersPercentageResolvedPending.ToArray())
                .ToListAsync();

            return new ListStatisticsResponse(
                incidentsByHourOfDay,
                heatMap,
                avgTimeOfResolutionByAddress,
                percentageResolvedPending);
        }

        #region Functions for Page Admin/Statistics
        internal StringBuilder MakeDateAddressFilters
            (ListStatisticsRequest request, List<SqlParameter> parameters)
        {
            var filter = new StringBuilder();

            if (request.StartDate is not null)
            {
                filter.Append(" AND i.CreatedAt >= @startDate");
                parameters.Add(new SqlParameter("@startDate", request.StartDate));
            }

            if (request.EndDate is not null)
            {
                filter.Append(" AND i.CreatedAt <= @endDate");
                parameters.Add(new SqlParameter("@endDate", request.EndDate));
            }

            if (!string.IsNullOrWhiteSpace(request.Address))
            {
                filter.Append(" AND i.Address = @address");
                parameters.Add(new SqlParameter("@address", request.Address));
            }

            return filter;
        }

        internal StringBuilder MakeHourFilters(
            ListStatisticsRequest request, List<SqlParameter> parameters, string column)
        {
            var filterHour = new StringBuilder();

            if (request.StartHour is not null)
            {
                filterHour.Append($" AND {column} >= @startHour");
                parameters.Add(new SqlParameter("@startHour", request.StartHour));
            }

            if (request.EndHour is not null)
            {
                filterHour.Append($" AND {column} <= @endHour");
                parameters.Add(new SqlParameter("@endHour", request.EndHour));
            }
            
            return filterHour;
        }
        #endregion
    }
}