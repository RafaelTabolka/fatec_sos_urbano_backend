using MediatR;
using SOSUrbano.Domain.Entities.UserEntity;
using SOSUrbano.Domain.Interfaces.Repositories.UserRepository;

namespace SOSUrbano.Domain.Comands.ComandsUser.UserTypeComands.Create
{
    internal class CreateUserTypeHandler
        (IRepositoryUserType repositoryUserType) :
        IRequestHandler<CreateUserTypeRequest, CreateUserTypeResponse>
    {
        public async Task<CreateUserTypeResponse> Handle
            (CreateUserTypeRequest request, CancellationToken cancellationToken)
        {
            var userType = new UserType(request.Name);
            await repositoryUserType.AddAsync(userType);
            await repositoryUserType.CommitAsync();

            return new CreateUserTypeResponse(
                userType.Id, "Tipo de usuário criado com sucesso");
        }
    }
}
