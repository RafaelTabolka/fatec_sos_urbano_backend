using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace SOSUrbano.Domain.Comands.ComandsUser.UserComands.Delete
{
    public class DeleteUserRequest(Guid id) : 
        IRequest<DeleteUserResponse>
    {
        public Guid Id { get; } = id;
    }
}
