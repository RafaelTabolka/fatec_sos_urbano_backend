using FluentValidation;

namespace SOSUrbano.Domain.Commands.CommandsIncident.IncidentStatusCommands.Create
{
    public class CreateIncidentStatusValidation : AbstractValidator<CreateIncidentStatusRequest>
    {
        public CreateIncidentStatusValidation()
        {
            RuleFor(status => status.Name)
                .NotEmpty().WithMessage("Nome do status é obrigatório.")
                .MaximumLength(50).WithMessage("Campo nome tem no máximo 50 caracteres.");
        }
    }
}
