using MediatR;
using SOSUrbano.Domain.Comands.UserComands.Get;
using SOSUrbano.Domain.Interfaces.Repositories.UserRepository;
using SOSUrbano.Domain.Interfaces.Services.LoginRepository;

namespace SOSUrbano.Domain.Comands.UserLoginComands.Login
{
    internal class LoginUserHandler 
        (IServiceLogin serviceLogin, IRepositoryUser repositoryUser):
        IRequestHandler<LoginUserRequest, LoginUserResponse>
    {
        public async Task<LoginUserResponse> Handle(
            LoginUserRequest request, CancellationToken cancellationToken)
        {
            var user = await repositoryUser.GetByEmailAndPassword(request.Email, request.Password);
            if (user is null)
                throw new Exception("Email ou senha inválidos");
            
            var accessToken = serviceLogin.GenerateToken(user.Id, user.Email, user.UserType.Name);
            return new LoginUserResponse(accessToken);
        }
    }
}
