using MediatR;
using SOSUrbano.Domain.Commands.CommandsInstitution.InstitutionEmailCommands.Create;
using SOSUrbano.Domain.Commands.CommandsInstitution.InstitutionPhoneCommands.Create;
using SOSUrbano.Domain.Entities.InstitutionEntity;

namespace SOSUrbano.Domain.Commands.CommandsInstitution.InstitutionCommands.Create
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
