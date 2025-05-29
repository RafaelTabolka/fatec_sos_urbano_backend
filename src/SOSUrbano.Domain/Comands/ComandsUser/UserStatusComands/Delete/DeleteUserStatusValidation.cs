using FluentValidation;

namespace SOSUrbano.Domain.Comands.ComandsUser.UserStatusComands.Delete
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
