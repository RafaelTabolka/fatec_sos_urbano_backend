using MediatR;
using SOSUrbano.Domain.Interfaces.Repositories.UserRepository;

namespace SOSUrbano.Domain.Commands.CommandsUser.UserTypeCommands.List
{
    internal class ListUserTypesHandler
        (IRepositoryUserType repositoryUserType) :
        IRequestHandler<ListUserTypesRequest, ListUserTypesResponse>
    {
        public async Task<ListUserTypesResponse> Handle
            (ListUserTypesRequest request, CancellationToken cancellationToken)
        {
            var userTypes = await repositoryUserType.GetAllAsync();
            return new ListUserTypesResponse(userTypes);
        }
    }
}
