using FluentValidation;

namespace SOSUrbano.Domain.Commands.CommandsInstitution.InstitutionCommands.Get
{
    public class GetInstitutionValidation : AbstractValidator<GetInstitutionRequest>
    {
        public GetInstitutionValidation()
        {
            RuleFor(i => i.Id)
                .NotEmpty().WithMessage("O campo Id é obrigatório.");
        }
    }
}
