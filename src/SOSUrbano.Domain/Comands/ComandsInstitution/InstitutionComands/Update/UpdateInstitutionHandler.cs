using MediatR;
using SOSUrbano.Domain.Interfaces.Repositories.InstitutionRepository;

namespace SOSUrbano.Domain.Comands.ComandsInstitution.InstitutionComands.Update
{
    internal class UpdateInstitutionHandler
        (IRepositoryInstitution repositoryInstitution,
        IRepositoryInstitutionStatus repositoryInstitutionStatus,
        IRepositoryInstitutionType repositoryInstitutionType) :
        IRequestHandler<UpdateInstitutionRequest, UpdateInstitutionResponse>
    {
        public async Task<UpdateInstitutionResponse> Handle
            (UpdateInstitutionRequest request, CancellationToken cancellationToken)
        {
            var institution = await repositoryInstitution.GetByIdAsync(request.Id);

            if (institution is null)
                throw new Exception("Instituição não encontrada.");

            var institutionStatus = await repositoryInstitutionStatus.
                GetStatusByNameAsync(request.InstitutionStatusName);

            var institutionType = await repositoryInstitutionType.
                GetTypeByNameAsync(request.InstitutionTypeName);

            institution.Name = request.Name;
            institution.UrlSite = request.UrlSite;
            institution.Description = request.Description;
            institution.Address = request.Address;
            institution.InstitutionStatusId = institutionStatus.Id;
            institution.InstitutionTypeId = institutionType.Id;
            institution.InstitutionEmails = request.InstitutionEmails;
            institution.InstitutionPhones = request.InstitutionPhones;

            repositoryInstitution.Update(institution);
            await repositoryInstitution.CommitAsync();

            return new UpdateInstitutionResponse(institution);
    }
    }
}
