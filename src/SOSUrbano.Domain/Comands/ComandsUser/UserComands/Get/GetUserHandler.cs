﻿using MediatR;
using SOSUrbano.Domain.Interfaces.Repositories.UserRepository;

namespace SOSUrbano.Domain.Comands.ComandsUser.UserComands.Get
{
    internal class GetUserHandler(IRepositoryUser repositoryUser) :
        IRequestHandler<GetUserRequest, GetUserResponse>
    {
        public async Task<GetUserResponse> Handle(GetUserRequest request, 
            CancellationToken cancellationToken)
        {
            //var user = await repositoryUser.GetUserById(request.Id);
            var user = await repositoryUser.GetByIdAsync(request.Id);

            if (user is null)
                throw new Exception("Usuário não encontrado.");
            return new GetUserResponse(user);
            
        }
    }
}
