using SOSUrbano.Domain.Commands.CommandsIncident.IncidentCommands.Dto;
using SOSUrbano.Domain.Commands.CommandsUser.UserPhoneCommands.Dto;
using SOSUrbano.Domain.Commands.CommandsUser.UserStatusCommands.Dto;
using SOSUrbano.Domain.Commands.CommandsUser.UserTypeCommands.Dto;

namespace SOSUrbano.Domain.Commands.CommandsUser.UserCommands.Dto
{
    public class DtoUserResponse(
        Guid id,
        string name,
        string email,
        string cpf,
        DtoUserTypeResponse userType,
        DtoUserStatusResponse userStatus,
        List<DtoUserPhoneResponse>? userPhones,
        List<DtoIncidentResponse>? incidents)
    {
        public Guid Id { get; } = id;

        public string Name { get; } = name;

        public string Email { get; } = email;

        public string Cpf { get; } = cpf;

        public DtoUserTypeResponse UserType { get; } = userType;

        public DtoUserStatusResponse UserStatus { get; } = userStatus;

        public List<DtoUserPhoneResponse>? UserPhones { get; } = userPhones;

        public List<DtoIncidentResponse>? Incidents { get; } = incidents;
    }
}
