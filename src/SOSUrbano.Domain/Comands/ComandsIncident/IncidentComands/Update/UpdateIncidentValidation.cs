using FluentValidation;

namespace SOSUrbano.Domain.Comands.ComandsIncident.IncidentComands.Update
{
    public class UpdateIncidentValidation : AbstractValidator<UpdateIncidentRequest>
    {
        public UpdateIncidentValidation()
        {
            RuleFor(i => i.Id)
                .NotEmpty().WithMessage("O campo Id é obrigatório.");

            RuleFor(i => i.Description)
                .NotEmpty().WithMessage("Descrição é um campo obrigatório.")
                .MaximumLength(500).WithMessage("Máximo permitido de 500 caracteres.");

            RuleFor(i => i.LatLocalization)
                .NotEmpty().WithMessage("Localização em latitude é obrigatório.");

            RuleFor(i => i.LongLocalization)
                .NotEmpty().WithMessage("Localização em longitude é obrigatório.");

            RuleFor(i => i.InstitutionName)
                .NotEmpty().WithMessage("O nome da instituição é obrigatório.");

            RuleFor(i => i.IncidentStatusName)
                .NotEmpty().WithMessage("O status da denúncia é obrigatório.");
        }
    }
}
