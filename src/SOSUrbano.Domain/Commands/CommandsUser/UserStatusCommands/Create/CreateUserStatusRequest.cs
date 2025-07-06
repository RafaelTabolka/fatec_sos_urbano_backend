using MediatR;

namespace SOSUrbano.Domain.Commands.CommandsUser.UserStatusCommands.Create
{
    public class CreateUserStatusRequest : 
        IRequest<CreateUserStatusResponse>
    {
        public string Name { get; set; } = string.Empty;
    }
}
