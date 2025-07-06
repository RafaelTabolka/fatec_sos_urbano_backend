using FluentValidation;

namespace SOSUrbano.Domain.Commands.CommandsUser.UserTypeCommands.Delete
{
    public class DeleteUserTypeValidation : AbstractValidator<DeleteUserTypeRequest>
    {
        public DeleteUserTypeValidation()
        {
            RuleFor(t => t.Id)
                .NotEmpty().WithMessage("O campo Id é obrigatório.");
        }
    }
}
