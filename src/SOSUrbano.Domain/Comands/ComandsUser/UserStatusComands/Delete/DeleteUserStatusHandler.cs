using MediatR;
using SOSUrbano.Domain.Interfaces.Repositories.UserRepository;

namespace SOSUrbano.Domain.Comands.ComandsUser.UserStatusComands.Delete
{
    internal class DeleteUserStatusHandler
        (IRepositoryUserStatus repositoryUserStatus) :
        IRequestHandler<DeleteUserStatusRequest, DeleteUserStatusResponse>
    {
        public async Task<DeleteUserStatusResponse> Handle
            (DeleteUserStatusRequest request, CancellationToken cancellationToken)
        {
            var userStatus = await repositoryUserStatus.GetByIdAsync(request.Id);

            if (userStatus is null)
                throw new Exception("Status não encontrado");

            repositoryUserStatus.Delete(userStatus.Id);

            await repositoryUserStatus.CommitAsync();

            return new DeleteUserStatusResponse("Status excluído com suecesso");
        }
    }
}
