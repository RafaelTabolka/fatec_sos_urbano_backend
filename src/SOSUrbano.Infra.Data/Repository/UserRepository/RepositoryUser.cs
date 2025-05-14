using Microsoft.EntityFrameworkCore;
using SOSUrbano.Domain.Entities.UserEntity;
using SOSUrbano.Domain.Interfaces.Repositories.UserRepository;
using SOSUrbano.Infra.Data.Context;
using SOSUrbano.Infra.Data.Repository.Base;

namespace SOSUrbano.Infra.Data.Repository.UserRepository
{
    internal class RepositoryUser(SOSUrbanoContext context) :
        RepositoryBase<User>(context), IRepositoryUser
    {
        /*
         A variável que possui _, no caso _context, é para simbolizar que a 
        variável em questão é readonly private, esse é o significado de _
         */
        private readonly SOSUrbanoContext _context = context;
        public async Task<IEnumerable<User>> ListByName(string name)
        {
            return await _context.UserSet.Where(p => 
            p.Name == name).ToListAsync();
        }
    }
}
