using MediatR;
using SOSUrbano.Domain.Entities.UserEntity;
using SOSUrbano.Domain.Interfaces.Repositories.UserRepository;
using SOSUrbano.Domain.Interfaces.Services.LoginRepository;
using Microsoft.AspNetCore.Identity;

namespace SOSUrbano.Domain.Comands.ComandsUser.UserComands.Create
{
    /*
     A classe handler vai orquestrar a requisição, ou seja, temos um request e um response da requisição,
    a request está conversando com o response graças ao IRequest<CreateUserResponse>. O handler
    é o maestro que vai gerenciar essa requisição e a resposta
     */
    internal class CreateUserHandler
        (IRepositoryUser repositoryUser, IServiceLogin serviceLogin,
        IRepositoryUserStatus repositoryUserStatus, IRepositoryUserType repositoryUserType) : 
        IRequestHandler<CreateUserRequest, CreateUserResponse>
    {
        public async Task<CreateUserResponse> Handle(
            CreateUserRequest request, CancellationToken cancellationToken)
        {
            var hasher = new PasswordHasher<object>();
            var hashedPassword = hasher.HashPassword
                (null!, request.Password);

            var userStatus = await repositoryUserStatus.GetByName(request.UserStatusName);
            var userType = await repositoryUserType.GetTypeByNameAsync(request.UserTypeName);

            var user = new User(
                request.Name,
                request.Email,
                request.Cpf,
                hashedPassword,
                userStatus.Id,
                userType.Id);

            user.UserPhones = request.UserPhones?
                .Select(phone => new UserPhone(user.Id, phone.Number))
                .ToList();

            await repositoryUser.AddAsync(user);
            await repositoryUser.CommitAsync();

            var cretedUser = await repositoryUser.GetByEmailAndPassword
                (user.Email, request.Password);

            string accessToken = serviceLogin.GenerateToken
                (cretedUser.Id, cretedUser.Email, cretedUser.UserType.Name);

            return new CreateUserResponse(cretedUser.Id, accessToken);
        }
    }
}
