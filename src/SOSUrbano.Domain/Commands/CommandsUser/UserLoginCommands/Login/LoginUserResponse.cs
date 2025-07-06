namespace SOSUrbano.Domain.Commands.CommandsUser.UserLoginCommands.Login
{
    public class LoginUserResponse(string accessToken)
    {
        public string AccessToken { get; } = accessToken;
    }
}
