using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace SOSUrbano.Domain.Comands.UserComands.Get
{
    public class GetUserRequest(Guid id) : IRequest<GetUserResponse>
    {
        public Guid Id { get; } = id;
    }
}
