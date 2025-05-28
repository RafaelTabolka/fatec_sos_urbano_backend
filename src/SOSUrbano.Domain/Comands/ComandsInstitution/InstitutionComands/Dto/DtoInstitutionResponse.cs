using SOSUrbano.Domain.Comands.ComandsInstitution.InstitutionEmailComands.Dto;
using SOSUrbano.Domain.Comands.ComandsInstitution.InstitutionPhoneComands.Dto;
using SOSUrbano.Domain.Comands.ComandsInstitution.InstitutionStatusComands.Dto;
using SOSUrbano.Domain.Comands.ComandsInstitution.InstitutionTypeComands.Dto;

namespace SOSUrbano.Domain.Comands.ComandsInstitution.InstitutionComands.Dto
{
    public class DtoInstitutionResponse(
    Guid id,
    string name,
    string cnpj,
    string? urlSite,
    string description,
    string address,
    DtoInstitutionStatusResponse institutionStatus,
    DtoInstitutionTypeResponse institutionType,
    List<DtoInstitutionEmailResponse> institutionEmails,
    List<DtoInstitutionPhoneResponse> institutionPhones)
    {
        public Guid Id { get; } = id;
        public string Name { get; } = name;

        public string Cnpj { get; } = cnpj;

        public string? UrlSite { get; } = urlSite;

        public string Description { get; } = description;

        public string Address { get; } = address;

        public DtoInstitutionStatusResponse InstitutionStatus { get; } = institutionStatus;

        public DtoInstitutionTypeResponse InstitutionType { get; } = institutionType;

        public List<DtoInstitutionEmailResponse> InstitutionEmail { get; } = institutionEmails;

        public List<DtoInstitutionPhoneResponse> InstitutionPhones { get; } = institutionPhones;
    }
}
