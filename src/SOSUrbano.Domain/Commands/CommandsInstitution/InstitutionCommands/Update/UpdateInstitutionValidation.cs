using FluentValidation;

namespace SOSUrbano.Domain.Commands.CommandsInstitution.InstitutionCommands.Update
{
    public class UpdateInstitutionValidation : AbstractValidator<UpdateInstitutionRequest>
    {
        public UpdateInstitutionValidation()
        {
            RuleFor(i => i.Id)
                .NotEmpty().WithMessage("Campo Id é obrigatório.");

            RuleFor(i => i.Name)
                .NotEmpty().WithMessage("Campo nome é obrigatório.")
                .MaximumLength(50).WithMessage("Campo nome pode ter até 50 caracteres.");

            RuleFor(i => i.UrlSite)
                .NotNull().WithMessage("Campo url site não pode ter espaços em branco")
                .MaximumLength(200).WithMessage("Campo url site pode ter até 200 caracteres");

            RuleFor(i => i.Description)
                .NotEmpty().WithMessage("Campo descrição é obrigatório.")
                .MaximumLength(500).WithMessage("Campo descrição pode ter até 500 caracteres.");

            RuleFor(i => i.Address)
                .NotEmpty().WithMessage("Campo endereço é obrigatório.")
                .MaximumLength(100).WithMessage("Campo endereço pode ter aé 100 caracteres.");
        }
    }
}
