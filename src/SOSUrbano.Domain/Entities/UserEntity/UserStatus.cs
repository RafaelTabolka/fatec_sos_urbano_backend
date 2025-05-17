using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SOSUrbano.Domain.Entities.Base;

namespace SOSUrbano.Domain.Entities.UserEntity
{
    public class UserStatus : EntityBase
    {
        public string Name { get; set; } = string.Empty;

        public UserStatus(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
        }

        public void AlterName(string newName)
        {
            Name = newName;
        }
    }
}
