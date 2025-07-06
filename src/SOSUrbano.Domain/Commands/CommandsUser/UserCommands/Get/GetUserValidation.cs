using FluentValidation;

namespace SOSUrbano.Domain.Commands.CommandsUser.UserCommands.Get
{
    public class GetUserValidation : AbstractValidator<GetUserRequest>
    {
        public GetUserValidation()
        {
            RuleFor(u => u.Id)
                .NotEmpty().WithMessage("O campo Id é obrigatório.");
        }
    }
}
