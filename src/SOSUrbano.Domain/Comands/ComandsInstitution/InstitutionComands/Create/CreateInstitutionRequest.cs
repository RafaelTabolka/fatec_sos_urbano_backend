using MediatR;
using SOSUrbano.Domain.Comands.ComandsInstitution.InstitutionEmailComands.Create;
using SOSUrbano.Domain.Comands.ComandsInstitution.InstitutionPhoneComands.Create;
using SOSUrbano.Domain.Entities.InstitutionEntity;

namespace SOSUrbano.Domain.Comands.ComandsInstitution.InstitutionComands.Create
{
    public class CreateInstitutionRequest :
        IRequest<CreateInstitutionResponse>
    {
        public string Name { get; set; } = string.Empty;
        public string Cnpj { get; set; } = string.Empty;
        public string? UrlSite { get; set; }
        public string Description { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string InstitutionStatusName { get; set; } = string.Empty;
        public string InstitutionTypeName { get; set; } = string.Empty;
        public List<CreateInstitutionEmailRequest> InstitutionEmails { get; set; } = [];
        public List<CreateInstitutionPhoneRequest> InstitutionPhones { get; set; } = [];
    }
}
