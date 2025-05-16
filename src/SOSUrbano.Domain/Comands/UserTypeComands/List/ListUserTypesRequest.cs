using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace SOSUrbano.Domain.Comands.UserTypeComands.List
{
    public class ListUserTypesRequest : IRequest<ListUserTypesResponse>;
}
