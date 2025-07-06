using MediatR;

namespace SOSUrbano.Domain.Commands.CommandsUser.UserTypeCommands.Delete
{
    public class DeleteUserTypeRequest(Guid id) :
        IRequest<DeleteUserTypeResponse>
    {
        public Guid Id { get; set; } = id;
    }
}
