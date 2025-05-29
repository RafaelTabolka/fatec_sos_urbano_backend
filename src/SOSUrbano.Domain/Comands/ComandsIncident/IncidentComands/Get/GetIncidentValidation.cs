using FluentValidation;

namespace SOSUrbano.Domain.Comands.ComandsIncident.IncidentComands.Get
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
