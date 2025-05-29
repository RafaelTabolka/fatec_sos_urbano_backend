using FluentValidation;

namespace SOSUrbano.Domain.Comands.ComandsInstitution.InstitutionEmailComands.Update
{
    public class UpdateInstitutionEmailValidation : AbstractValidator<UpdateInstitutionEmailRequest>
    {
        public UpdateInstitutionEmailValidation()
        {
            RuleFor(i => i.Id)
                .NotEmpty().WithMessage("O campo Id é obrigatório.");

            RuleFor(i => i.EmailAddress)
                .NotEmpty().WithMessage("O campo email é obrigatório.")
                .MaximumLength(50).WithMessage("O campo email deve ter no máximo 50 caracteres.");
        }
    }
}
