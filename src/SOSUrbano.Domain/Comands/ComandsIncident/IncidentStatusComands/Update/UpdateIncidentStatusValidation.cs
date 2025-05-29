using FluentValidation;

namespace SOSUrbano.Domain.Comands.ComandsIncident.IncidentStatusComands.Update
{
    public class UpdateIncidentStatusValidation : AbstractValidator<UpdateIncidentStatusRequest>
    {
        public UpdateIncidentStatusValidation()
        {
            RuleFor(status => status.Id)
                .NotEmpty().WithMessage("O campo Id é obrigatório.");

            RuleFor(status => status.Name)
                .NotEmpty().WithMessage("O campo nome é obrigatório.")
                .MaximumLength(50).WithMessage("O campo nome pode no máximo 50 caracteres.");
        }
    }
}
