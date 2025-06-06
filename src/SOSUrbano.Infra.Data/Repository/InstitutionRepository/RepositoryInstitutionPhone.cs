﻿using SOSUrbano.Domain.Entities.InstitutionEntity;
using SOSUrbano.Domain.Interfaces.Repositories.InstitutionRepository;
using SOSUrbano.Infra.Data.Context;
using SOSUrbano.Infra.Data.Repository.Base;

namespace SOSUrbano.Infra.Data.Repository.InstitutionRepository
{
    public class RepositoryInstitutionPhone
        (SOSUrbanoContext context) :
        RepositoryBase<InstitutionPhone>(context),
        IRepositoryInstitutionPhone
    {
    }
}
