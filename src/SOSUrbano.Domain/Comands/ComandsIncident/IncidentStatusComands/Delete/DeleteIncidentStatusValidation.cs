using FluentValidation;

namespace SOSUrbano.Domain.Comands.ComandsIncident.IncidentStatusComands.Delete
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
