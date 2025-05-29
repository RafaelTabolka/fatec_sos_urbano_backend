using FluentValidation;

namespace SOSUrbano.Domain.Comands.ComandsUser.UserTypeComands.Delete
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
