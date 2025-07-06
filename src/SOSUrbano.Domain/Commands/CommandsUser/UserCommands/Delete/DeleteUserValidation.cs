using FluentValidation;

namespace SOSUrbano.Domain.Commands.CommandsUser.UserCommands.Delete
{
    public class DeleteUserValidation : AbstractValidator<DeleteUserRequest>
    {
        public DeleteUserValidation()
        {
            RuleFor(u => u.Id)
                .NotEmpty().WithMessage("O campo Id é obrigatório.");
        }
    }
}
