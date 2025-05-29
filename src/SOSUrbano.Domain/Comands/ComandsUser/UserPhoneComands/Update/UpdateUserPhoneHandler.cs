using MediatR;
using SOSUrbano.Domain.Interfaces.Repositories.UserRepository;

namespace SOSUrbano.Domain.Comands.ComandsUser.UserPhoneComands.Update
{
    internal class UpdateUserPhoneHandler
        (IRepositoryUserPhone repositoryUserPhone) :
        IRequestHandler<UpdateUserPhoneRequest, UpdateUserPhoneResponse>
    {
        public async Task<UpdateUserPhoneResponse> Handle
            (UpdateUserPhoneRequest request, CancellationToken cancellationToken)
        {
            var userPhone = await repositoryUserPhone.
                GetByIdAsync(request.Id);

            if (userPhone is null)
                throw new Exception("Telefone não encontrado");

            userPhone.Number = request.Number;

            repositoryUserPhone.Update(userPhone);

            await repositoryUserPhone.CommitAsync();

            return new UpdateUserPhoneResponse("Atualizado com sucesso");
        }
    }
}
