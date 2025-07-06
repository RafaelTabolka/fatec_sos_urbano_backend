using MediatR;

namespace SOSUrbano.Domain.Commands.CommandsUser.UserTypeCommands.Create
{
    public class CreateUserTypeRequest : IRequest<CreateUserTypeResponse>
    {
        public string Name { get; set; } = string.Empty;
    }
}
