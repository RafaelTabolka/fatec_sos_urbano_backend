using MediatR;
using SOSUrbano.Domain.Interfaces.Repositories.UserRepository;
using SOSUrbano.Domain.Interfaces.Services.LoginRepository;
using ValidationException = FluentValidation.ValidationException;

namespace SOSUrbano.Domain.Commands.CommandsUser.UserLoginCommands.Login
{
    internal class LoginUserHandler 
        (IServiceLogin serviceLogin, IRepositoryUser repositoryUser):
        IRequestHandler<LoginUserRequest, LoginUserResponse>
    {
        public async Task<LoginUserResponse> Handle(
            LoginUserRequest request, CancellationToken cancellationToken)
        {
            var validator = new LoginUserValidation();

            var validationResult = validator.Validate(request);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var user = await repositoryUser.GetByEmailAndPasswordAsync(request.Email, request.Password);
            
            if (user is null)
                throw new Exception("Email ou senha inválidos");
            
            var accessToken = serviceLogin.GenerateToken(user.Id, user.Email, user.UserType.Name);
            return new LoginUserResponse(accessToken);
        }
    }
}
