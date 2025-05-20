using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace SOSUrbano.Domain.Comands.ComandsInstitution.InstitutionStatusComands.Create
{
    internal class CreateInstitutionStatusRequest :
        IRequest<CreateInstitutionStatusResponse>
    {
        public string Name { get; set; } = string.Empty;
    }
}
