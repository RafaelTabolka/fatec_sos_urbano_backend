using MediatR;
using SOSUrbano.Domain.Entities.InstitutionEntity;
using SOSUrbano.Domain.Interfaces.Repositories.InstitutionRepository;

namespace SOSUrbano.Domain.Comands.ComandsInstitution.InstitutionStatusComands.Create
{
    public class CreateInstitutionStatusHandler
        (IRepositoryInstitutionStatus repositoryInstitutionStatus):
        IRequestHandler<CreateInstitutionStatusRequest, CreateInstitutionStatusResponse>
    {
        public async Task<CreateInstitutionStatusResponse> 
            Handle(CreateInstitutionStatusRequest request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(request.Name))
                throw new Exception("Usuário Obrigatório");

            var entityStatus = new InstitutionStatus(request.Name);

            await repositoryInstitutionStatus.AddAsync(entityStatus);
            await repositoryInstitutionStatus.CommitAsync();

            return new CreateInstitutionStatusResponse(entityStatus.Id);
        }
    }
}
