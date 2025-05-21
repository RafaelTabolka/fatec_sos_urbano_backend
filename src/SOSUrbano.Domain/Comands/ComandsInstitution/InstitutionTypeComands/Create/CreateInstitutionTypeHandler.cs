using MediatR;
using SOSUrbano.Domain.Entities.InstitutionEntity;
using SOSUrbano.Domain.Interfaces.Repositories.InstitutionRepository;

namespace SOSUrbano.Domain.Comands.ComandsInstitution.InstitutionTypeComands.Create
{
    public class CreateInstitutionTypeHandler
        (IRepositoryInstitutionType repositoryInstitutionType) :
        IRequestHandler<CreateInstitutionTypeRequest, CreateInstitutionTypeResponse>
    {
        public async Task<CreateInstitutionTypeResponse> Handle
            (CreateInstitutionTypeRequest request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(request.Name))
                throw new Exception("Nome obrigatório");

            var entityType = new InstitutionType(request.Name);

            await repositoryInstitutionType.AddAsync(entityType);
            await repositoryInstitutionType.CommitAsync();

            return new CreateInstitutionTypeResponse(entityType.Id);

        }
    }
}
