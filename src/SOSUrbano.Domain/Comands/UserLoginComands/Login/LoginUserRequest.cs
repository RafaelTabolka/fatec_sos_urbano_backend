using MediatR;

namespace SOSUrbano.Domain.Comands.UserLoginComands.Login
{
    public class LoginUserRequest(string email, string password)
        : IRequest<LoginUserResponse>
    {
        public string Email { get; set; } = email;
        public string Password { get; set; } = password;
    }
}
