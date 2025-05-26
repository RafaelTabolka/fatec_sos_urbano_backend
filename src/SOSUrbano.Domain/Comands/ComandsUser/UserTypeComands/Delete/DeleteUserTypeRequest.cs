using MediatR;

namespace SOSUrbano.Domain.Comands.ComandsUser.UserTypeComands.Delete
{
    public class DeleteUserTypeRequest(Guid id) :
        IRequest<DeleteUserTypeResponse>
    {
        public Guid Id { get; set; } = id;
    }
}
