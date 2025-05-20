using Microsoft.EntityFrameworkCore;
using SOSUrbano.Domain.Comands.UserLoginComands.Login;
using SOSUrbano.Domain.Entities.UserEntity;
using SOSUrbano.Domain.Interfaces.Repositories.UserRepository;
using SOSUrbano.Infra.Data.Context;
using SOSUrbano.Infra.Data.Repository.Base;
using Microsoft.AspNetCore.Identity;

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
         Esse _context é a variável que tem acesso ao banco. Ai quando fizermos um
        _context.UserSet, estamos acessando as colunas da tabela UserSet.
        A propriedade UserSet tem conhecimento das colunas da tabela de usuários
         */
        private readonly SOSUrbanoContext _context = context;
        public async Task<IEnumerable<User>> ListByName(string name)
        {
            return await _context.UserSet
                .Where(p => p.Name == name).ToListAsync();
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

        /*
            Método	                    Quando usar
        FirstOrDefaultAsync	    1 ou nenhum resultado esperado
        FirstAsync	            1 resultado esperado (erro se nenhum)
        SingleOrDefaultAsync    espera exatamente 1 ou nenhum
        SingleAsync	            espera exatamente 1 (erro se mais de 1)
        ToListAsync	            quer vários resultados
         */

        public async Task<User> GetByEmailAndPassword
            (string email, string password)
        {
            /*
             Não se pode utilizar a expressão da verificação da senha
            criptografada com a senha passada direto na consulta, 
            porque o EF não consegue transformar o 
            hasher.VerifyHashedPassword em SQL, logo vai dar pau.
            Então o ideal é buscar o usuário só pelo email e depois,
            localmente na função, verificar se a senha desse usuário
            buscado pelo email, é a mesma senha passada no parâmetro do
            método.
             */

            var user = await _context.UserSet
                .Include(u => u.UserType)
                .FirstOrDefaultAsync
                (u => u.Email == email);

            if (user is null)
                throw new Exception("Usuário não encontrado");
   
            var hasher = new PasswordHasher<Object>();
            var result = hasher.VerifyHashedPassword
                (null!, user.Password, password);

            if (result == PasswordVerificationResult.Success)
                return user;
            throw new Exception("Usuário ou senha incorretos");
        }
    }
}
