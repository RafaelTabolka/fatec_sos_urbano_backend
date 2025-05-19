namespace SOSUrbano.Domain.Comands.UserLoginComands.Login
{
    public class LoginUserResponse(string accessToken)
    {
        public string AccessToken { get; } = accessToken;
    }
}
