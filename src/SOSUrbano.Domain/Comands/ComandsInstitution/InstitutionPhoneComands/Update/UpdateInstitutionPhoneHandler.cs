using MediatR;
using SOSUrbano.Domain.Interfaces.Repositories.InstitutionRepository;

namespace SOSUrbano.Domain.Comands.ComandsInstitution.InstitutionPhoneComands.Update
{
    internal class UpdateInstitutionPhoneHandler
        (IRepositoryInstitutionPhone repositoryInstitutionPhone) :
        IRequestHandler<UpdateInstitutionPhoneRequest, UpdateInstitutionPhoneResponse>
    {
        public async Task<UpdateInstitutionPhoneResponse> Handle
            (UpdateInstitutionPhoneRequest request, CancellationToken cancellationToken)
        {
            var institutionPhone = await repositoryInstitutionPhone
                .GetByIdAsync(request.Id);

            if (institutionPhone is null)
                throw new Exception("Número não encontrado.");

            institutionPhone.Number = request.Number;

            repositoryInstitutionPhone.Update(institutionPhone);

            await repositoryInstitutionPhone.CommitAsync();

            return new UpdateInstitutionPhoneResponse("Atualizado com sucesso");
        }
    }
}
