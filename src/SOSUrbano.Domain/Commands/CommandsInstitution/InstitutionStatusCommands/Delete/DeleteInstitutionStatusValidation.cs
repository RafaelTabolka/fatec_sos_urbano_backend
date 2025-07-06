using FluentValidation;

namespace SOSUrbano.Domain.Commands.CommandsInstitution.InstitutionStatusCommands.Delete
{
    public class DeleteInstitutionStatusValidation : AbstractValidator<DeleteInstitutionStatusRequest>
    {
        public DeleteInstitutionStatusValidation()
        {
            RuleFor(i => i.Id)
                .NotEmpty().WithMessage("O campo Id é obrigatório.");
        }
    }
}
