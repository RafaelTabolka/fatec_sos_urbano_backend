using MediatR;

namespace SOSUrbano.Domain.Commands.CommandsUser.UserStatusCommands.Delete
{
    public class DeleteUserStatusRequest(Guid id) :
        IRequest<DeleteUserStatusResponse>
    {
        public Guid Id { get; set; } = id;
    }
}
