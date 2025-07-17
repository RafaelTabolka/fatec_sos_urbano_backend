using SOSUrbano.Domain.Commands.CommandsAdmin.AdminUsersCommands.Dto;

namespace SOSUrbano.Domain.Commands.CommandsAdmin.AdminUsersCommands.ListUsers
{
    public class ListUsersForAdminResponse(List<AdminUsersDto> adminUsersDtos)
    {
        public List<AdminUsersDto> AdminUserDtos { get; } = adminUsersDtos;
    }
}
