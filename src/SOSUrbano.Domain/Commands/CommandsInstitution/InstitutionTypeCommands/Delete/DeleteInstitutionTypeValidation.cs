using FluentValidation;

namespace SOSUrbano.Domain.Commands.CommandsInstitution.InstitutionTypeCommands.Delete
{
    public class DeleteInstitutionTypeValidation : AbstractValidator<DeleteInstitutionTypeRequest>
    {
        public DeleteInstitutionTypeValidation()
        {
            RuleFor(i => i.Id)
                .NotEmpty().WithMessage("O campo Id é obrigatório.");
        }
    }
}
