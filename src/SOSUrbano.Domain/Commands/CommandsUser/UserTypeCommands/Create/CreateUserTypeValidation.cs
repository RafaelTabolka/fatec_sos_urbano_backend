﻿using FluentValidation;

namespace SOSUrbano.Domain.Commands.CommandsUser.UserTypeCommands.Create
{
    public class CreateUserTypeValidation : AbstractValidator<CreateUserTypeRequest>
    {
        public CreateUserTypeValidation()
        {
            RuleFor(t => t.Name)
                .NotEmpty().WithMessage("O campo nome é obrigatório.")
                .MaximumLength(50).WithMessage("O campo nome deve ter no máximo 50 caracteres.");
        }
    }
}
