using FluentValidation;

namespace SOSUrbano.Domain.Commands.CommandsIncident.IncidentCommands.Get
{
    public class GetIncidentValidation : AbstractValidator<GetIncidentRequest>
    {
        public GetIncidentValidation()
        {
            RuleFor(i => i.Id)
                .NotEmpty().WithMessage("O campo Id é obrigatório.");
        }
    }
}
