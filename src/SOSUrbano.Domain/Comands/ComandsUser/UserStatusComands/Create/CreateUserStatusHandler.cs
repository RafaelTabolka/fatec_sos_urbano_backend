using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using SOSUrbano.Domain.Entities.UserEntity;
using SOSUrbano.Domain.Interfaces.Repositories.UserRepository;

namespace SOSUrbano.Domain.Comands.ComandsUser.UserStatusComands.Create
{
    internal class CreateUserStatusHandler
        (IRepositoryUserStatus repository) :
        IRequestHandler<CreateUserStatusRequest, CreateUserStatusResponse>
    {
        public async Task<CreateUserStatusResponse> Handle
            (CreateUserStatusRequest request, CancellationToken cancellationToken)
        {
            var userStatus = new UserStatus(request.Name);
            await repository.AddAsync(userStatus);
            await repository.CommitAsync();

            return new CreateUserStatusResponse(userStatus.Id, "Status criado com sucesso");

        }
    }
}
