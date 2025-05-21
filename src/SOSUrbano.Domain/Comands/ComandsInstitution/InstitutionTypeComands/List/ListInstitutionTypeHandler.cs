using MediatR;
using SOSUrbano.Domain.Interfaces.Repositories.InstitutionRepository;

namespace SOSUrbano.Domain.Comands.ComandsInstitution.InstitutionTypeComands.List
{
    public class ListInstitutionTypeHandler
        (IRepositoryInstitutionType repositoryInstitutionType):
        IRequestHandler<ListInstitutionTypeRequest, ListInstitutionTypeResponse>
    {
        public async Task<ListInstitutionTypeResponse> Handle
            (ListInstitutionTypeRequest request, CancellationToken cancellationToken)
        {
            var types = await repositoryInstitutionType.GetAllAsync();

            return new ListInstitutionTypeResponse(types.ToList());
        }
    }
}
