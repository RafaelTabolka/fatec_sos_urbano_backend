using FluentValidation;

namespace SOSUrbano.Domain.Comands.ComandsUser.UserComands.Delete
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
