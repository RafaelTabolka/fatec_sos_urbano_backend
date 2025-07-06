using FluentValidation;

namespace SOSUrbano.Domain.Commands.CommandsUser.UserCommands.Create
{
    public class CreateUserValidation : AbstractValidator<CreateUserRequest>
    {
        public CreateUserValidation()
        {
            RuleFor(u => u.Name)
                .NotEmpty().WithMessage("O campo nome é obrigatório.")
                .MaximumLength(50).WithMessage("O campo nome deve ter no máximo 50 caracteres.");
            
            RuleFor(u => u.Email)
                .NotEmpty().WithMessage("O campo email é obrigatório.")
                .MaximumLength(100).WithMessage("O campo email deve ter no máximo 100 caracteres.");

            RuleFor(u => u.Cpf)
                .NotEmpty().WithMessage("O campo CPF é obrigatório.")
                .MaximumLength(11).MinimumLength(11).WithMessage("O campo CPF deve conter 11 números.");

            RuleFor(u => u.Password)
                .NotEmpty().WithMessage("O campo senha é obrigatório.")
                .MinimumLength(8).WithMessage("O campo senha deve ter no mínimo 8 caracteres.");

            RuleFor(u => u.TermsOfUse)
                .NotEmpty().WithMessage("O campo termos de uso é obrigatório.")
                .Equal(true).WithMessage("É necessário aceitar os termos de uso.");

            RuleFor(u => u.UserStatusName)
                .NotEmpty().WithMessage("O campo status do usuário é obrigatório.");

            RuleFor(u => u.UserTypeName)
                .NotEmpty().WithMessage("O campo tipo do usuário é obrigatório.");

            RuleFor(u => u.UserPhones)
                .NotEmpty().NotNull().WithMessage("O campo telefones do usuário é obrigatório.");

            RuleForEach(u => u.UserPhones)
                .ChildRules(phones =>
                {
                    phones.RuleFor(phone => phone.Number)
                    .NotEmpty().WithMessage("Deve haver pelo menos um número de telefone.")
                    .MaximumLength(11).MinimumLength(10)
                    .WithMessage("O número de telefone deve conter entre 10 a 11 números.");
                });
        }
    }
}
