using SOSUrbano.Domain.Comands.ComandsIncident.IncidentComands.Dto;
using SOSUrbano.Domain.Comands.ComandsUser.UserPhoneComands.Dto;
using SOSUrbano.Domain.Comands.ComandsUser.UserStatusComands.Dto;
using SOSUrbano.Domain.Comands.ComandsUser.UserTypeComands.Dto;

namespace SOSUrbano.Domain.Comands.ComandsUser.UserComands.Dto
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
