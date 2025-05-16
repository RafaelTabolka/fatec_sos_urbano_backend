using MediatR;
using SOSUrbano.Domain.Entities.UserEntity;
using SOSUrbano.Domain.Interfaces.Repositories.UserRepository;

namespace SOSUrbano.Domain.Comands.UserComands.Create
{
    /*
     A classe handler vai orquestrar a requisição, ou seja, temos um request e um response da requisição,
    a request está conversando com o response graças ao IRequest<CreateUserResponse>. O handler
    é o maestro que vai gerenciar essa requisição e a resposta
     */
    internal class CreateUserHandler(IRepositoryUser repositoryUser) : 
        IRequestHandler<CreateUserRequest, CreateUserResponse>
    {
        public async Task<CreateUserResponse> Handle(
            CreateUserRequest request, CancellationToken cancellationToken)
        {
            var user = new User(
                request.Name,
                request.Email,
                request.Cpf,
                request.Password,
                request.UserStatusId,
                request.UserTypeId);

            user.UserPhones = request.UserPhones?
                .Select(phone => new UserPhone(user.Id, phone.Number))
                .ToList();

            await repositoryUser.AddAsync(user);
            await repositoryUser.CommitAsync();

            return new CreateUserResponse(user.Id, "Usuário criado com sucesso.");
        }
    }
}
