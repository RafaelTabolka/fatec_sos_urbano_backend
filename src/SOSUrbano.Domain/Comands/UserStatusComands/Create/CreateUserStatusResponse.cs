using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOSUrbano.Domain.Comands.UserStatusComands.Create
{
    public class CreateUserStatusResponse(Guid id, string message)
    {
        public Guid Id { get; } = id;
        public string Message { get; } = message;
    }
}
