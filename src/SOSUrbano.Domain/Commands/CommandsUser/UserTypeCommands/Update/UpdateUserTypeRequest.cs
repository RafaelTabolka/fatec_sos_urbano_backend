using MediatR;

namespace SOSUrbano.Domain.Commands.CommandsUser.UserTypeCommands.Update
{
    public class UpdateUserTypeRequest :
        IRequest<UpdateUserTypeResponse>
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
