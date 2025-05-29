using FluentValidation;

namespace SOSUrbano.Domain.Comands.ComandsUser.UserTypeComands.Update
{
    public class UpdateUserTypeValidation : AbstractValidator<UpdateUserTypeRequest>
    {
        public UpdateUserTypeValidation()
        {
            RuleFor(t => t.Id)
                .NotEmpty().WithMessage("O campo Id é obrigatório.");

            RuleFor(t => t.Name)
                .NotEmpty().WithMessage("O campo nome é obrigatório.")
                .MaximumLength(50).WithMessage("O campo nome deve conter no máximo 50 caracteres.");
        }
    }
}
