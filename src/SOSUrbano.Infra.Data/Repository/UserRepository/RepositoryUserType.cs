using SOSUrbano.Domain.Entities.UserEntity;
using SOSUrbano.Domain.Interfaces.Repositories.UserRepository;
using SOSUrbano.Infra.Data.Context;
using SOSUrbano.Infra.Data.Repository.Base;

namespace SOSUrbano.Infra.Data.Repository.UserRepository
{
    public class RepositoryUserType(SOSUrbanoContext context) :
        RepositoryBase<UserType>(context), IRepositoryUserType;
}
