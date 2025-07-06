using FluentValidation;

namespace SOSUrbano.Domain.Commands.CommandsInstitution.InstitutionCommands.Delete
{
    public class DeleteInstitutionValidation : AbstractValidator<DeleteInstitutionRequest>
    {
        public DeleteInstitutionValidation()
        {
            RuleFor(i => i.Id)
                .NotEmpty().WithMessage("O campo Id é obrigatório.");
        }
    }
}
