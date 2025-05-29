using FluentValidation;

namespace SOSUrbano.Domain.Comands.ComandsInstitution.InstitutionStatusComands.Create
{
    public class CreateInstitutionStatusValidation : AbstractValidator<CreateInstitutionStatusRequest>
    {
        public CreateInstitutionStatusValidation()
        {
            RuleFor(i => i.Name)
                .NotEmpty().WithMessage("Campo nome é obriatório.")
                .MaximumLength(20).WithMessage("Campo nome deve ter no máximo 20 caracteres.");
        }
    }
}
