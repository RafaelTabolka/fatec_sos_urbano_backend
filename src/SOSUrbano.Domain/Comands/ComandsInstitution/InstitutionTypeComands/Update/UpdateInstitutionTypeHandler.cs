using MediatR;
using SOSUrbano.Domain.Interfaces.Repositories.InstitutionRepository;

namespace SOSUrbano.Domain.Comands.ComandsInstitution.InstitutionTypeComands.Update
{
    internal class UpdateInstitutionTypeHandler
        (IRepositoryInstitutionType repositoryInstitutionType) :
        IRequestHandler<UpdateInstitutionTypeRequest, UpdateInstitutionTypeResponse>
    {
        public async Task<UpdateInstitutionTypeResponse> Handle
            (UpdateInstitutionTypeRequest request, CancellationToken cancellationToken)
        {
            var institutionType = await repositoryInstitutionType.GetByIdAsync(request.Id);

            if (institutionType is null)
                throw new Exception("Tipo não encontrado.");

            institutionType.Name = request.Name;

            repositoryInstitutionType.Update(institutionType);

            await repositoryInstitutionType.CommitAsync();

            return new UpdateInstitutionTypeResponse("Atualizado com sucesso");
        }
    }
}
