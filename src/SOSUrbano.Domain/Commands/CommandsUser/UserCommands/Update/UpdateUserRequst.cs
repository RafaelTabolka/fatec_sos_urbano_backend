using MediatR;

namespace SOSUrbano.Domain.Commands.CommandsUser.UserCommands.Update
{
    public class UpdateUserRequst :
        IRequest<UpdateUserResponse>
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Cpf { get; set; } = string.Empty;

        public string UserStatusName { get; set; } = string.Empty;

        public string UserTypeName { get; set; } = string.Empty;
    }
}
