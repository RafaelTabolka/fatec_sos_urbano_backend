using MediatR;
using SOSUrbano.Domain.Entities.UserEntity;
using SOSUrbano.Domain.Interfaces.Repositories.UserRepository;

namespace SOSUrbano.Domain.Comands.ComandsUser.UserComands.Update
{
    internal class UpdateUserHandler
        (IRepositoryUser repositoryUser,
        IRepositoryUserStatus repositoryUserStatus,
        IRepositoryUserType repositoryUserType) :
        IRequestHandler<UpdateUserRequst, UpdateUserResponse>
    {
        public async Task<UpdateUserResponse> Handle
            (UpdateUserRequst request, CancellationToken cancellationToken)
        {
            var user = await repositoryUser.GetByIdAsync(request.Id);

            if (user is null)
                throw new Exception("Usuário não encontrado");

            var userStatus = await repositoryUserStatus.GetByStatusAsync
                (request.UserStatusName);

            var userType = await repositoryUserType.GetByTypeAsync
                (request.UserTypeName);

            user.Name = request.Name;
            user.Email = request.Email;
            user.Cpf = request.Cpf;
            user.UserStatusId = userStatus.Id;
            user.UserTypeId = userType.Id;

            repositoryUser.Update(user);
            await repositoryUser.CommitAsync();

            return new UpdateUserResponse(user);
        }
    }
}
