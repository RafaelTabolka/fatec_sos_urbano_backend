using Microsoft.EntityFrameworkCore;
using SOSUrbano.Domain.Entities.UserEntity;
using SOSUrbano.Domain.Interfaces.Repositories.UserRepository;
using SOSUrbano.Infra.Data.Context;
using SOSUrbano.Infra.Data.Repository.Base;

namespace SOSUrbano.Infra.Data.Repository.UserRepository
{
    public class RepositoryUserStatus(SOSUrbanoContext context) :
        RepositoryBase<UserStatus>(context), IRepositoryUserStatus
    {
        private readonly SOSUrbanoContext _context = context;
        public async Task<UserStatus> GetByName(string name)
        {
            var userStatus = await _context.UserStatusesSet
                .FirstOrDefaultAsync(status => EF.Functions.Like(status.Name, name));

            if (userStatus is null)
                throw new Exception("Status não encontrado");

            return userStatus;
        }

        public async Task<UserStatus> GetByStatusAsync(string statusName)
        {
            var userStatus = await _context.UserStatusesSet
                .FirstOrDefaultAsync(status => EF.Functions.Like
                (status.Name, statusName));

            if (userStatus is null)
                throw new Exception("Status não encontrado.");

            return userStatus;
        }
    }
}
