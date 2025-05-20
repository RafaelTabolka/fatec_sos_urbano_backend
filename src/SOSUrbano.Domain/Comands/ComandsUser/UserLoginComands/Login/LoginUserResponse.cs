namespace SOSUrbano.Domain.Comands.ComandsUser.UserLoginComands.Login
{
    public class LoginUserResponse(string accessToken)
    {
        public string AccessToken { get; } = accessToken;
    }
}
