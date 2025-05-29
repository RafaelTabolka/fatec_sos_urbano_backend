using FluentValidation;

namespace SOSUrbano.Domain.Comands.ComandsInstitution.InstitutionPhoneComands.Update
{
    public class UpdateInstitutionPhoneValidation : AbstractValidator<UpdateInstitutionPhoneRequest>
    {
        public UpdateInstitutionPhoneValidation()
        {
            RuleFor(i => i.Id)
                .NotEmpty().WithMessage("Campo Id é obrigatório.");

            RuleFor(i => i.Number)
                .NotEmpty().WithMessage("Campo telefone é obrigatório.")
                .MaximumLength(11).MinimumLength(10)
                .WithMessage("O telefone deve ter entre 10 a 11 números");
        }
    }
}
