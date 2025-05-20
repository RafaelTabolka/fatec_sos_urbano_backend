using MediatR;

namespace SOSUrbano.Domain.Comands.ComandsUser.UserComands.Get
{
    public class GetUserRequest(Guid id) : IRequest<GetUserResponse>
    {
        public Guid Id { get; } = id;
    }
}
