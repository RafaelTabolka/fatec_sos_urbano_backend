using FluentValidation;

namespace SOSUrbano.Domain.Commands.CommandsIncident.IncidentStatusCommands.Delete
{
    public class DeleteIncidentStatusValidation : AbstractValidator<DeleteIncidentStatusRequest>
    {
        public DeleteIncidentStatusValidation()
        {
            RuleFor(status => status.Id)
                .NotEmpty().WithMessage("O campo Id é obrigatório");
        }
    }
}
