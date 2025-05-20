using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using SOSUrbano.Domain.Entities.UserEntity;
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
            return new ListUserResponse(users);
        }
    }
}
