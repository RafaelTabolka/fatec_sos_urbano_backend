using SOSUrbano.Domain.Comands.UserLoginComands.Login;
using SOSUrbano.Domain.Entities.UserEntity;
using SOSUrbano.Domain.Interfaces.Repositories.Base;

namespace SOSUrbano.Domain.Interfaces.Services.LoginRepository
{
    public interface IServiceLogin
    {
        string GenerateToken(Guid id, string email, string roleName);
    }
}
