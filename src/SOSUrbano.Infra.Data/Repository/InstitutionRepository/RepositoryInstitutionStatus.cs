using Microsoft.EntityFrameworkCore;
using SOSUrbano.Domain.Entities.InstitutionEntity;
using SOSUrbano.Domain.Interfaces.Repositories.InstitutionRepository;
using SOSUrbano.Infra.Data.Context;
using SOSUrbano.Infra.Data.Repository.Base;

namespace SOSUrbano.Infra.Data.Repository.InstitutionRepository
{
    public class RepositoryInstitutionStatus
        (SOSUrbanoContext context) :
        RepositoryBase<InstitutionStatus>(context),
        IRepositoryInstitutionStatus
    {
        private readonly SOSUrbanoContext _context = context;
        public async Task<InstitutionStatus> GetStatusByNameAsync(string name)
        {
            var status = await _context.InstitutionStatusSet
                .FirstOrDefaultAsync
                (status => EF.Functions.Like(status.Name, name));

            if (status is null)
                throw new Exception("Status não encontrado.");

            return status;
        }
    }
}
