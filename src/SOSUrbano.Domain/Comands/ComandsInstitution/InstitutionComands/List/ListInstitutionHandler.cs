using MediatR;
using SOSUrbano.Domain.Comands.ComandsInstitution.InstitutionComands.Dto;
using SOSUrbano.Domain.Comands.ComandsInstitution.InstitutionEmailComands.Dto;
using SOSUrbano.Domain.Comands.ComandsInstitution.InstitutionPhoneComands.Dto;
using SOSUrbano.Domain.Comands.ComandsInstitution.InstitutionStatusComands.Dto;
using SOSUrbano.Domain.Comands.ComandsInstitution.InstitutionTypeComands.Dto;
using SOSUrbano.Domain.Interfaces.Repositories.InstitutionRepository;

namespace SOSUrbano.Domain.Comands.ComandsInstitution.InstitutionComands.List
{
    internal class ListInstitutionHandler
        (IRepositoryInstitution repositoryInstitution) :
        IRequestHandler<ListInstitutionRequest, ListInstitutionResponse>
    {
        public async Task<ListInstitutionResponse> Handle
            (ListInstitutionRequest request, CancellationToken cancellationToken)
        {
            var institutions = await repositoryInstitution.GetAllInstitutions();

            var response = institutions.Select(i =>
            new DtoInstitutionResponse(
                i.Id,
                i.Name,
                i.Cnpj,
                i.UrlSite,
                i.Description,
                i.Address,
                new DtoInstitutionStatusResponse(i.InstitutionStatus.Name),
                new DtoInstitutionTypeResponse(i.InstitutionType.Name),
                i.InstitutionEmails.Select(email =>
                new DtoInstitutionEmailResponse(email.EmailAddress)).ToList(),
                i.InstitutionPhones.Select(phone =>
                new DtoInstitutionPhoneResponse(phone.Number)).ToList()));

            return new ListInstitutionResponse(response);
        }
    }
}
