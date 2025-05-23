using MediatR;
using SOSUrbano.Domain.Entities.UserEntity;
using SOSUrbano.Domain.Interfaces.Repositories.UserRepository;

namespace SOSUrbano.Domain.Comands.ComandsUser.UserComands.Update
{
    internal class UpdateUserHandler
        (IRepositoryUser repositoryUser) :
        IRequestHandler<UpdateUserRequst, UpdateUserResponse>
    {
        public async Task<UpdateUserResponse> Handle
            (UpdateUserRequst request, CancellationToken cancellationToken)
        {
            var user = await repositoryUser.GetByIdAsync(request.Id);

            user = new User(
                request.Id,
                request.Name,
                request.Email,
                request.Cpf);

            repositoryUser.Update(user);
            await repositoryUser.CommitAsync();

            return new UpdateUserResponse(user);
        }
    }
}
