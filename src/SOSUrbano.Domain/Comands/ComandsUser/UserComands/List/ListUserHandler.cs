using MediatR;
using SOSUrbano.Domain.Interfaces.Repositories.UserRepository;

namespace SOSUrbano.Domain.Comands.ComandsUser.UserComands.List
{
    internal class ListUserHandler(IRepositoryUser repositoryUser) :
        IRequestHandler<ListUserRequest, ListUserResponse>
    {
        public async Task<ListUserResponse> Handle(ListUserRequest request, 
            CancellationToken cancellationToken)
        {
            var users = await repositoryUser.GetAllAsync();
            //Após terminar as entidades, busque pelo id das entidades
            // que queira para adicionar na lista users. 
            //users.Select(user => user.propriedade)
            return new ListUserResponse(users);
        }
    }
}
