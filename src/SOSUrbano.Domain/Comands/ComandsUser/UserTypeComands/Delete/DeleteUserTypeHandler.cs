using MediatR;
using SOSUrbano.Domain.Interfaces.Repositories.UserRepository;

namespace SOSUrbano.Domain.Comands.ComandsUser.UserTypeComands.Delete
{
    internal class DeleteUserTypeHandler
        (IRepositoryUserType repositoryUserType) :
        IRequestHandler<DeleteUserTypeRequest, DeleteUserTypeResponse>
    {
        public async Task<DeleteUserTypeResponse> Handle
            (DeleteUserTypeRequest request, CancellationToken cancellationToken)
        {
            var userType = await repositoryUserType.
                GetByIdAsync(request.Id);

            if (userType is null)
                throw new Exception("Tipo não encontrado");

            repositoryUserType.Delete(userType.Id);

            await repositoryUserType.CommitAsync();

            return new DeleteUserTypeResponse("Tipo excluído com sucesso");
        }
    }
}
