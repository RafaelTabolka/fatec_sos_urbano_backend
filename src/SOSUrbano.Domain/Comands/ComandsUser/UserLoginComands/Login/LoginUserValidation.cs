using FluentValidation;

namespace SOSUrbano.Domain.Comands.ComandsUser.UserLoginComands.Login
{
    public class LoginUserValidation : AbstractValidator<LoginUserRequest>
    {
        public LoginUserValidation()
        {
            RuleFor(u => u.Email)
                .NotEmpty().WithMessage("O campo email é obrigatório.");

            RuleFor(u => u.Password)
                .NotEmpty().WithMessage("O campo senha é obrigatório.");
        }
    }
}
