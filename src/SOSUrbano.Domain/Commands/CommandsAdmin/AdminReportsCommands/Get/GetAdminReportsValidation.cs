using FluentValidation;

namespace SOSUrbano.Domain.Commands.CommandsAdmin.AdminReportsCommands.Get
{
    public class GetAdminReportsValidation : AbstractValidator<GetAdminReportsRequest>
    {
        //public GetDashboardValidation()
        //{
        //    RuleFor(u => u.Id)
        //        .NotEmpty().WithMessage("O campo Id é obrigatório.");
        //}
    }
}
