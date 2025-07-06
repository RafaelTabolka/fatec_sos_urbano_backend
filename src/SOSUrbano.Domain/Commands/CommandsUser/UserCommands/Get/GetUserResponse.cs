using SOSUrbano.Domain.Commands.CommandsUser.UserCommands.Dto;

namespace SOSUrbano.Domain.Commands.CommandsUser.UserCommands.Get
{
    public class GetUserResponse(DtoUserResponse user)
    {
        public DtoUserResponse User { get; set; } = user;
    }
}
