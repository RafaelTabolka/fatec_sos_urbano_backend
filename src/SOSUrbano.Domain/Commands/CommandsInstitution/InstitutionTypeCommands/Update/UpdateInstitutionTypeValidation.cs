using FluentValidation;

namespace SOSUrbano.Domain.Commands.CommandsInstitution.InstitutionTypeCommands.Update
{
    public class UpdateInstitutionTypeValidation : AbstractValidator<UpdateInstitutionTypeRequest>
    {
        public UpdateInstitutionTypeValidation()
        {
            RuleFor(i => i.Id)
                .NotEmpty().WithMessage("O campo Id é obrigatório.");

            RuleFor(i => i.Name)
                .NotEmpty().WithMessage("O campo nome é obrigatório.")
                .MaximumLength(20).WithMessage("O campo nome deve ter no máximo 20 caracteres.");
        }
    }
}
