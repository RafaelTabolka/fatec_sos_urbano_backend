namespace SOSUrbano.Domain.Interfaces.Services.LoginRepository
{
    public interface IServiceLogin
    {
        string GenerateToken(Guid id, string email, string roleName);
    }
}
