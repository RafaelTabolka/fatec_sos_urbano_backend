using MediatR;

namespace SOSUrbano.Domain.Commands.CommandsUser.UserStatusCommands.Update
{
    public class UpdateUserStatusRequest :
        IRequest<UpdateUserStatusResponse>
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
