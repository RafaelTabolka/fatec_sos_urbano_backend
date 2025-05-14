using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SOSUrbano.Domain.Entities.Base;

namespace SOSUrbano.Domain.Entities.UserEntity
{
    public class UserPhone : EntityBase
    {
        public string Number { get; set; } = null!;
    }
}
