using MediatR;
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

            return new ListInstitutionResponse(institutions);
        }
    }
}
