using MediatR;
using SOSUrbano.Domain.Comands.ComandsInstitution.InstitutionComands.Dto;
using SOSUrbano.Domain.Comands.ComandsInstitution.InstitutionEmailComands.Dto;
using SOSUrbano.Domain.Comands.ComandsInstitution.InstitutionPhoneComands.Dto;
using SOSUrbano.Domain.Comands.ComandsInstitution.InstitutionStatusComands.Dto;
using SOSUrbano.Domain.Comands.ComandsInstitution.InstitutionTypeComands.Dto;
using SOSUrbano.Domain.Interfaces.Repositories.InstitutionRepository;

namespace SOSUrbano.Domain.Comands.ComandsInstitution.InstitutionComands.Get
{
    internal class GetInstitutionHandler
        (IRepositoryInstitution repositoryInstitution) :
        IRequestHandler<GetInstitutionRequest, GetInstitutionResponse>
    {
        public async Task<GetInstitutionResponse> Handle
            (GetInstitutionRequest request, CancellationToken cancellationToken)
        {
            var institution = await repositoryInstitution.GetInstitutionByIdAsync(request.Id);


            if (institution is null)
                throw new Exception("Instituição não encontrada.");
            
            var response = new DtoInstitutionResponse(
                institution.Id,
                institution.Name,
                institution.Cnpj,
                institution.UrlSite,
                institution.Description,
                institution.Address,
                new DtoInstitutionStatusResponse(institution.InstitutionStatus.Name),
                new DtoInstitutionTypeResponse(institution.InstitutionType.Name),
                institution.InstitutionEmails.Select(email =>
                new DtoInstitutionEmailResponse(email.EmailAddress)).ToList(),
                institution.InstitutionPhones.Select(phone =>
                new DtoInstitutionPhoneResponse(phone.Number)).ToList());
            
            return new GetInstitutionResponse(response);
        }
    }
}
