using FluentValidation;

namespace SOSUrbano.Domain.Comands.ComandsInstitution.InstitutionStatusComands.Delete
{
    public class DeleteInstitutionStatusValidation : AbstractValidator<DeleteInstitutionStatusRequest>
    {
        public DeleteInstitutionStatusValidation()
        {
            RuleFor(i => i.Id)
                .NotEmpty().WithMessage("O campo Id é obrigatório.");
        }
    }
}
