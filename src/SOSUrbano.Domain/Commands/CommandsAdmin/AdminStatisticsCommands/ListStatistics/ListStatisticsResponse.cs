using SOSUrbano.Domain.Commands.CommandsAdmin.AdminStatisticsCommands.Dto;

namespace SOSUrbano.Domain.Commands.CommandsAdmin.AdminStatisticsCommands.ListStatistics
{
    public class ListStatisticsResponse(
        List<AdminsIncidentsByHourOfDayDto> adminsIncidentsByHourOfDayDtos,
        List<AdminHeatMapDto> adminHeatMapDtos,
        List<AdminAvgTimeResolutionAddressDto> adminAvgTimeResolutionAddressDtos,
        List<AdminPercentageResolvedPendingDto> adminPercentageResolvedPendingDtos)
    {
        public List<AdminsIncidentsByHourOfDayDto> AdminsIncidentsByHourOfDayDtos { get; } =
            adminsIncidentsByHourOfDayDtos;

        public List<AdminHeatMapDto> AdminHeatMapDtos { get; } = adminHeatMapDtos;

        public List<AdminAvgTimeResolutionAddressDto> AdminAvgTimeResolutionAddressDtos { get; } =
            adminAvgTimeResolutionAddressDtos;

        public List<AdminPercentageResolvedPendingDto> AdminPercentageResolvedPendingDtos { get; } =
            adminPercentageResolvedPendingDtos;
    }
}
