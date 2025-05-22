using MediatR;
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
            var institution = await repositoryInstitution.GetByIdAsync(request.Id);

            if (institution is null)
                throw new Exception("Instituição não encontrada.");
            return new GetInstitutionResponse(institution);
        }
    }
}
