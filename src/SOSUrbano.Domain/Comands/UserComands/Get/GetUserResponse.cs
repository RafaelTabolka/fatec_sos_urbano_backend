using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SOSUrbano.Domain.Entities.UserEntity;

namespace SOSUrbano.Domain.Comands.UserComands.Get
{
    public class GetUserResponse(User user)
    {
        public User User { get; set; } = user;
    }
}
