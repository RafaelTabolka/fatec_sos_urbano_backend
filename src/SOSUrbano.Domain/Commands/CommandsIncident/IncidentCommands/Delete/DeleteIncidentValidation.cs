using FluentValidation;

namespace SOSUrbano.Domain.Commands.CommandsIncident.IncidentCommands.Delete
{
    public class DeleteIncidentValidation : AbstractValidator<DeleteIncidentRequest>
    {
        public DeleteIncidentValidation()
        {
            RuleFor(i => i.Id)
                .NotEmpty().WithMessage("O campo Id é obrigatório.");
        }
    }
}
