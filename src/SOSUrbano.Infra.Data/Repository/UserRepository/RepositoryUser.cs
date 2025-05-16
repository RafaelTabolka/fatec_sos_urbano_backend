using Microsoft.EntityFrameworkCore;
using SOSUrbano.Domain.Entities.UserEntity;
using SOSUrbano.Domain.Interfaces.Repositories.UserRepository;
using SOSUrbano.Infra.Data.Context;
using SOSUrbano.Infra.Data.Repository.Base;

namespace SOSUrbano.Infra.Data.Repository.UserRepository
{
    public class RepositoryUser(SOSUrbanoContext context) :
        RepositoryBase<User>(context), IRepositoryUser
    {
        /*
         A variável que possui _, no caso _context, é para simbolizar que a 
        variável em questão é readonly private, esse é o significado de _
         */
        
        /*
         Esse _context é a variável que tem acesso ao banco. Ai quando fazemos um
        _context.UserSet, estamos acessando as colunas da tabela UserSet.
        A propriedade UserSet tem conhecimento das colunas dessa tabela de usuários
         */
        private readonly SOSUrbanoContext _context = context;
        public async Task<IEnumerable<User>> ListByName(string name)
        {
            return await _context.UserSet.Where(p => 
            p.Name == name).ToListAsync();
        }

        public async Task<User> GetUserById(Guid id)
        {
            var user = await _context.UserSet
                .Include(u => u.UserPhones)
                .Include(u => u.UserStatus)
                .Include(u => u.UserType)
                .FirstOrDefaultAsync(u => u.Id == id);

            if (user is null)
                throw new Exception("Usuário não encontrado");    
            return user;

        }
    }
}
