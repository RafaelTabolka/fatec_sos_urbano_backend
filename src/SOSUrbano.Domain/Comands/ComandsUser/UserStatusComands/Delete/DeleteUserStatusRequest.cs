using MediatR;

namespace SOSUrbano.Domain.Comands.ComandsUser.UserStatusComands.Delete
{
    public class DeleteUserStatusRequest(Guid id) :
        IRequest<DeleteUserStatusResponse>
    {
        public Guid Id { get; set; } = id;
    }
}
