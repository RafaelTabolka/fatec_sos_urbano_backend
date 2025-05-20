using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOSUrbano.Domain.Comands.ComandsInstitution.InstitutionStatusComands.Create
{
    internal class CreateInstitutionStatusResponse(Guid id)
    {
        public Guid Id { get; } = id;
    }
}
