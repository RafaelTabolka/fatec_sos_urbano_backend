using MediatR;

namespace SOSUrbano.Domain.Commands.CommandsUser.UserCommands.Get
{
    public class GetUserRequest(Guid id) : IRequest<GetUserResponse>
    {
        public Guid Id { get; } = id;
    }
}
