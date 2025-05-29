using MediatR;
using SOSUrbano.Domain.Interfaces.Repositories.UserRepository;

namespace SOSUrbano.Domain.Comands.ComandsUser.UserStatusComands.Update
{
    internal class UpdateUserStatusHandler
        (IRepositoryUserStatus repositoryUserStatus) :
        IRequestHandler<UpdateUserStatusRequest, UpdateUserStatusResponse>
    {
        public async Task<UpdateUserStatusResponse> Handle
            (UpdateUserStatusRequest request, CancellationToken cancellationToken)
        {
            var userStatus = await repositoryUserStatus.GetByIdAsync(request.Id);

            if (userStatus is null)
                throw new Exception("Status não encontrado");

            userStatus.Name = request.Name;

            repositoryUserStatus.Update(userStatus);

            await repositoryUserStatus.CommitAsync();

            return new UpdateUserStatusResponse("Atualizado com sucesso");
        }
    }
}
