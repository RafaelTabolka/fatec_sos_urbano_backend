using FluentValidation;

namespace SOSUrbano.Domain.Commands.CommandsUser.UserStatusCommands.Delete
{
    public class DeleteUserStatusValidation : AbstractValidator<DeleteUserStatusRequest>
    {
        public DeleteUserStatusValidation()
        {
            RuleFor(s => s.Id)
                .NotEmpty().WithMessage("O campo Id é obrigatório.");
        }
    }
}
