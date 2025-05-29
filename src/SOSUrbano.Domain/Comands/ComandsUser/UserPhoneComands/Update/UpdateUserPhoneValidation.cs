using FluentValidation;

namespace SOSUrbano.Domain.Comands.ComandsUser.UserPhoneComands.Update
{
    public class UpdateUserPhoneValidation : AbstractValidator<UpdateUserPhoneRequest>
    {
        public UpdateUserPhoneValidation()
        {
            RuleFor(p => p.Id)
                .NotEmpty().WithMessage("O campo Id é obrigatório.");

            RuleFor(p => p.Number)
                .NotEmpty().WithMessage("O campo número é obrigatório.")
                .MaximumLength(11).MinimumLength(10)
                .WithMessage("O campo número deve ter entre 10 a 11 números.");
        }
    }
}
