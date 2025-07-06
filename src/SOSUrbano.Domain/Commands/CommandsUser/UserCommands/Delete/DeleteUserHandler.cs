using MediatR;
using SOSUrbano.Domain.Interfaces.Repositories.UserRepository;

namespace SOSUrbano.Domain.Commands.CommandsUser.UserCommands.Delete
{
    internal class DeleteUserHandler(IRepositoryUser repositoryUser) :
        IRequestHandler<DeleteUserRequest, DeleteUserResponse>
    {
        public async Task<DeleteUserResponse> Handle(DeleteUserRequest request,
            CancellationToken cancellationToken)
        {
            var user = await repositoryUser.GetByIdAsync(request.Id);

            if (user is null)
                throw new Exception("Usuário não encontrado");

            repositoryUser.Delete(user.Id);
            await repositoryUser.CommitAsync();
            return new DeleteUserResponse($"Usuário excluído: {user.Name}");
        }
    }
}
