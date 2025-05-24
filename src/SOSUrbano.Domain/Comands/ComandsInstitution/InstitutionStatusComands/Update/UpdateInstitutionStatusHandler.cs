using MediatR;
using SOSUrbano.Domain.Interfaces.Repositories.InstitutionRepository;

namespace SOSUrbano.Domain.Comands.ComandsInstitution.InstitutionStatusComands.Update
{
    internal class UpdateInstitutionStatusHandler
        (IRepositoryInstitutionStatus repositoryInstitutionStatus) :
        IRequestHandler<UpdateInstitutionStatusRequest, UpdateInstitutionStatusResponse>
    {
        public async Task<UpdateInstitutionStatusResponse> Handle
            (UpdateInstitutionStatusRequest request, CancellationToken cancellationToken)
        {
            var institutionStatus = await repositoryInstitutionStatus.
                GetByIdAsync(request.Id);

            if (institutionStatus is null)
                throw new Exception("Status não encontrado.");

            institutionStatus.Name = request.Name;

            repositoryInstitutionStatus.Update(institutionStatus);

            await repositoryInstitutionStatus.CommitAsync();

            return new UpdateInstitutionStatusResponse(institutionStatus);
        }
    }
}
