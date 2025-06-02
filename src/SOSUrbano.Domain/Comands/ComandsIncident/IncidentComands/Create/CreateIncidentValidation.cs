using FluentValidation;

namespace SOSUrbano.Domain.Comands.ComandsIncident.IncidentComands.Create
{
    internal class CreateIncidentValidation : AbstractValidator<CreateIncidentRequest>
    {
        public CreateIncidentValidation()
        {
            RuleFor(i => i.Description)
                .NotEmpty().WithMessage("Descrição é obrigatório.")
                .MaximumLength(500).WithMessage("Descrição deve ter no máximo 500 caracteres.");

            RuleFor(i => i.LatLocalization)
                .NotEmpty().WithMessage("Localização em laitude não pode ser vazio.");

            RuleFor(i => i.LongLocalization)
                .NotEmpty().WithMessage("Locaização em longitude não pode ser vazio.");

            RuleFor(i => i.IncidentPhotoRequest)
                .NotEmpty().NotNull().WithMessage("Obrigatório ao menos uma foto.");

            RuleForEach(i => i.IncidentPhotoRequest)
                .ChildRules(photo =>
                {
                    photo.RuleFor(p => p.FileName)
                    .NotEmpty().WithMessage("Nome da foto é obrigatória.");

                    photo.RuleFor(p => p.FileName)
                    .Must(name => name.Length <= 500)
                    .WithMessage("Limite de 500 caracteres");
                });

            RuleFor(i => i.InstitutionName)
                .NotEmpty().WithMessage("Nome da instituição é obrigatório.");

            RuleFor(i => i.IncidentStatusName)
                .NotEmpty().WithMessage("Status da denúncia é obrigatório.");

            RuleFor(i => i.UserId)
                .NotEmpty().WithMessage("Id do usuário é obrigatório.");
        }
    }
}
