using MediatR;
using SOSUrbano.Domain.Interfaces.Repositories.UserRepository;

namespace SOSUrbano.Domain.Comands.ComandsUser.UserStatusComands.List
{
    internal class ListUserStatusHandler
        (IRepositoryUserStatus repositoryUserStatus) :
        IRequestHandler<ListUserStatusRequest, ListUserStatusResponse>
    {
        public async Task<ListUserStatusResponse> Handle
            (ListUserStatusRequest request, CancellationToken cancellationToken)
        {
            var userStatuses = await repositoryUserStatus.GetAllAsync();
            return new ListUserStatusResponse(userStatuses);
        }
    }
}
