using FluentValidation;

namespace SOSUrbano.Domain.Commands.CommandsInstitution.InstitutionTypeCommands.Create
{
    public class CreateInstitutionTypeValidation : AbstractValidator<CreateInstitutionTypeRequest>
    {
        public CreateInstitutionTypeValidation()
        {
            RuleFor(i => i.Name)
                .NotEmpty().WithMessage("O campo nome é obrigatório.")
                .MaximumLength(20).WithMessage("O campo nome deve ter no máximo 20 caracteres.");
        }
    }
}
