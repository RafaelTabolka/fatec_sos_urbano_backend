using FluentValidation;

namespace SOSUrbano.Domain.Commands.CommandsUser.UserCommands.Update
{
    public class UpdateUserValidation : AbstractValidator<UpdateUserRequst>
    {
        public UpdateUserValidation()
        {
            RuleFor(u => u.Id)
                .NotEmpty().WithMessage("O campo Id é obrigatório.");

            RuleFor(u => u.Name)
                .NotEmpty().WithMessage("O campo nome é obrigatório.")
                .MaximumLength(50).WithMessage("O campo nome deve ter no máximo 50 caracteres.");

            RuleFor(u => u.Email)
                .NotEmpty().WithMessage("O campo email é obrigatório.")
                .MaximumLength(100).WithMessage("O campo email deve ter no máximo 100 caracteres.");

            RuleFor(u => u.Cpf)
                .NotEmpty().WithMessage("O campo cpf é obrigatório")
                .MaximumLength(11).MinimumLength(11).WithMessage("O campo cpf deve ter 11 números.");

            RuleFor(u => u.UserStatusName)
                .NotEmpty().WithMessage("O campo status do usuário é obrigatório.");

            RuleFor(u => u.UserTypeName)
                .NotEmpty().WithMessage("O campo tipo de usuário é obrigatório.");
        }
    }
}
