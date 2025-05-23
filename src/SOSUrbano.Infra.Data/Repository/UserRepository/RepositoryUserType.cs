using Microsoft.EntityFrameworkCore;
using SOSUrbano.Domain.Entities.UserEntity;
using SOSUrbano.Domain.Interfaces.Repositories.UserRepository;
using SOSUrbano.Infra.Data.Context;
using SOSUrbano.Infra.Data.Repository.Base;

namespace SOSUrbano.Infra.Data.Repository.UserRepository
{
    public class RepositoryUserType(SOSUrbanoContext context) :
        RepositoryBase<UserType>(context), IRepositoryUserType
    {
        private readonly SOSUrbanoContext _context = context;

        public async Task<UserType> GetTypeByNameAsync(string name)
        {
            var userType = await _context.UserTypeSet
                .FirstOrDefaultAsync(type => EF.Functions.Like(type.Name, name));

            if (userType is null)
                throw new Exception("Tipo não encontrado.");

            return userType;
        }

        public async Task<UserType> GetByTypeAsync(string typeName)
        {
            var userType = await _context.UserTypeSet
                .FirstOrDefaultAsync(type => EF.Functions.Like
                (type.Name, typeName));

            if (userType is null)
                throw new Exception("Tipo não encontrado.");

            return userType;
        }
    }
}
