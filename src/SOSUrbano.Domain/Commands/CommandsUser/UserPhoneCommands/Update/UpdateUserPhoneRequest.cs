using MediatR;

namespace SOSUrbano.Domain.Commands.CommandsUser.UserPhoneCommands.Update
{
    public class UpdateUserPhoneRequest :
        IRequest<UpdateUserPhoneResponse>
    {
        public Guid Id { get; set; }
        public string Number { get; set; } = string.Empty;

    }
}
