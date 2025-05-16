using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SOSUrbano.Domain.Entities.UserEntity;
using SOSUrbano.Domain.Interfaces.Repositories.Base;

namespace SOSUrbano.Domain.Interfaces.Repositories.UserRepository
{
    public interface IRepositoryUserType : IRepositoryBase<UserType>;
}
