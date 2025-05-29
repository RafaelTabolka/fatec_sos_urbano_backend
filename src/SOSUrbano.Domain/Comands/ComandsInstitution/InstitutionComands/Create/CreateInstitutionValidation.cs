using FluentValidation;

namespace SOSUrbano.Domain.Comands.ComandsInstitution.InstitutionComands.Create
{
    public class CreateInstitutionValidation : AbstractValidator<CreateInstitutionRequest>
    {
        public CreateInstitutionValidation()
        {
            RuleFor(i => i.Name)
                .NotEmpty().WithMessage("O campo nome é obrigatório.")
                .MaximumLength(50).WithMessage("Campo nome com máximo de 50 caracteres.");

            RuleFor(i => i.Cnpj)
                .NotEmpty().WithMessage("Campo CNPJ é obrigatório.")
                .MaximumLength(14).WithMessage("Campo CNPJ possui no máximo 14 caracteres")
                .MinimumLength(14).WithMessage("Campo CNPJ possui no mínimo 14 caracteres");

            RuleFor(i => i.UrlSite)
                .NotNull().WithMessage("O campo url site pode ser nulo, mas não deve ter espaços em branco.")
                .MaximumLength(200).WithMessage("Campo url site pode ter no máximo 200 caracteres.");

            RuleFor(i => i.Description)
                .NotEmpty().WithMessage("O campo descrição é obrigatória.")
                .MaximumLength(500).WithMessage("Campo descrição com máximo de 500 caracteres.");

            RuleFor(i => i.Address)
                .NotEmpty().WithMessage("Campo endereço é obrigatório.")
                .MaximumLength(100).WithMessage("Campo endereço pode ter no máximo 100 caracteres.");

            RuleFor(i => i.InstitutionStatusName)
                .NotEmpty().WithMessage("Campo status nome é obrigatório.");

            RuleFor(i => i.InstitutionTypeName)
                .NotEmpty().WithMessage("O campo tipo é obrigatório.");

            RuleFor(i => i.InstitutionEmails)
                .NotEmpty().NotNull().WithMessage("Email não pode ser vazio.");

            RuleForEach(i => i.InstitutionEmails)
                .ChildRules(emails =>
                {
                    emails.RuleFor(email => email.EmailAddress)
                    .NotEmpty().WithMessage("Deve haver ao menos um email.")
                    .MaximumLength(50).WithMessage("Email deve conter no máximo 50 caracteres.");
                });

            RuleFor(i => i.InstitutionPhones)
                .NotEmpty().NotNull().WithMessage("O campo telefone é obrigatório.");

            RuleForEach(i => i.InstitutionPhones)
                .ChildRules(phones =>
                {
                    phones.RuleFor(phone => phone.Number)
                    .NotEmpty().WithMessage("Deve haver pelo menos um número de telefone.")
                    .MaximumLength(11).MinimumLength(10)
                    .WithMessage("O campo deve conter entre 10 e 11 caracteres");
                });
        }
    }
}
