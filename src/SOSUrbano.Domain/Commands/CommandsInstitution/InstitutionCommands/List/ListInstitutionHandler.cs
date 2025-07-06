using MediatR;
using SOSUrbano.Domain.Commands.CommandsInstitution.InstitutionCommands.Dto;
using SOSUrbano.Domain.Commands.CommandsInstitution.InstitutionEmailCommands.Dto;
using SOSUrbano.Domain.Commands.CommandsInstitution.InstitutionPhoneCommands.Dto;
using SOSUrbano.Domain.Commands.CommandsInstitution.InstitutionStatusCommands.Dto;
using SOSUrbano.Domain.Commands.CommandsInstitution.InstitutionTypeCommands.Dto;
using SOSUrbano.Domain.Interfaces.Repositories.InstitutionRepository;

namespace SOSUrbano.Domain.Commands.CommandsInstitution.InstitutionCommands.List
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
                new DtoInstitutionStatusResponse(i.InstitutionStatusId, i.InstitutionStatus.Name),
                new DtoInstitutionTypeResponse(i.InstitutionTypeId, i.InstitutionType.Name),
                i.InstitutionEmails.Select(email =>
                new DtoInstitutionEmailResponse(email.Id, email.EmailAddress)).ToList(),
                i.InstitutionPhones.Select(phone =>
                new DtoInstitutionPhoneResponse(phone.Id, phone.Number)).ToList()));

            return new ListInstitutionResponse(response);
        }
    }
}
