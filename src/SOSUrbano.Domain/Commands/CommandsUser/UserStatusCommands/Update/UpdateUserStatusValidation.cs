using FluentValidation;

namespace SOSUrbano.Domain.Commands.CommandsUser.UserStatusCommands.Update
{
    public class UpdateUserStatusValidation : AbstractValidator<UpdateUserStatusRequest>
    {
        public UpdateUserStatusValidation()
        {
            RuleFor(s => s.Id)
                .NotEmpty().WithMessage("O campo Id é obrigatório.");

            RuleFor(s => s.Name)
                .NotEmpty().WithMessage("O campo nome é obrigatório.")
                .MaximumLength(20).WithMessage("O campo nome deve ter no máximo 20 caracteres.");
        }
    }
}
