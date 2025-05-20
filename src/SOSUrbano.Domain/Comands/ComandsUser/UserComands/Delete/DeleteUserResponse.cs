using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOSUrbano.Domain.Comands.ComandsUser.UserComands.Delete
{
    public class DeleteUserResponse(string message)
    {
        public string Message { get; } = message;
    }
}
