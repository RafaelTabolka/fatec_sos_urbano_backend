using Microsoft.EntityFrameworkCore;
using SOSUrbano.Domain.Entities.InstitutionEntity;
using SOSUrbano.Domain.Interfaces.Repositories.InstitutionRepository;
using SOSUrbano.Infra.Data.Context;
using SOSUrbano.Infra.Data.Repository.Base;

namespace SOSUrbano.Infra.Data.Repository.InstitutionRepository
{
    public class RepositoryInstitutionType
        (SOSUrbanoContext context) :
        RepositoryBase<InstitutionType>(context),
        IRepositoryInstitutionType
    {
        private readonly SOSUrbanoContext _context = context;

        public async Task<InstitutionType> GetTypeByNameAsync(string name)
        {
            var type = await _context.InstitutionTypeSet
                .FirstOrDefaultAsync
                (type => EF.Functions.Like(type.Name, name));

            if (type is null)
                throw new Exception("Tipo não encontrado.");

            return type;
        }
    }
}
