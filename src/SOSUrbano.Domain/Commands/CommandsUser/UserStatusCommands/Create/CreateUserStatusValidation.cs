using FluentValidation;

namespace SOSUrbano.Domain.Commands.CommandsUser.UserStatusCommands.Create
{
    public class CreateUserStatusValidation : AbstractValidator<CreateUserStatusRequest>
    {
        public CreateUserStatusValidation()
        {
            RuleFor(s => s.Name)
                .NotEmpty().WithMessage("O campo nome é obrigatório.")
                .MaximumLength(20).WithMessage("O campo nome deve ter no máximo 20 caracteres.");
        }
    }
}
