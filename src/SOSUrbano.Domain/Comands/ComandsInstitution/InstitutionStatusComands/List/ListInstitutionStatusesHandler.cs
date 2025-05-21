using MediatR;
using SOSUrbano.Domain.Interfaces.Repositories.InstitutionRepository;

namespace SOSUrbano.Domain.Comands.ComandsInstitution.InstitutionStatusComands.List
{
    public class ListInstitutionStatusesHandler
        (IRepositoryInstitutionStatus repositoryInstitutionStatus) :
        IRequestHandler<ListInstitutionStatusesRequest, ListInstitutionStatusesResponse>
    {
        public async Task<ListInstitutionStatusesResponse> Handle
            (ListInstitutionStatusesRequest request, CancellationToken cancellationToken)
        {
            var statuses = await repositoryInstitutionStatus.GetAllAsync();

            return new ListInstitutionStatusesResponse(statuses.ToList());
        }
    }
}
