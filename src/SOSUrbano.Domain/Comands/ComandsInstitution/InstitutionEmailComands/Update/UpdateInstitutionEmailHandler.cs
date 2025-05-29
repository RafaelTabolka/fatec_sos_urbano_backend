using MediatR;
using SOSUrbano.Domain.Interfaces.Repositories.InstitutionRepository;

namespace SOSUrbano.Domain.Comands.ComandsInstitution.InstitutionEmailComands.Update
{
    internal class UpdateInstitutionEmailHandler
        (IRepositoryInstitutionEmail repositoryInstitutionEmail) :
        IRequestHandler<UpdateInstitutionEmailRequest, UpdateInstitutionEmailResponse>
    {
        public async Task<UpdateInstitutionEmailResponse> Handle
            (UpdateInstitutionEmailRequest request, CancellationToken cancellationToken)
        {
            var institutionEmail = await repositoryInstitutionEmail.
                GetByIdAsync(request.Id);

            if (institutionEmail is null)
                throw new Exception("Email não encontrado");

            institutionEmail.EmailAddress = request.EmailAddress;

            return new UpdateInstitutionEmailResponse("Atualizado com sucesso");
        }
    }
}
