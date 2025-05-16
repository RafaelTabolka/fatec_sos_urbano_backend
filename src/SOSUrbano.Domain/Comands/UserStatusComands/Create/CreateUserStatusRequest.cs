using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace SOSUrbano.Domain.Comands.UserStatusComands.Create
{
    public class CreateUserStatusRequest : 
        IRequest<CreateUserStatusResponse>
    {
        public string Name { get; set; } = string.Empty;
    }
}
