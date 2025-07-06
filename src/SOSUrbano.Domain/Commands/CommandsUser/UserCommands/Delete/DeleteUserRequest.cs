using MediatR;

namespace SOSUrbano.Domain.Commands.CommandsUser.UserCommands.Delete
{
    public class DeleteUserRequest(Guid id) : 
        IRequest<DeleteUserResponse>
    {
        public Guid Id { get; } = id;
    }
}
