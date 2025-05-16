using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using SOSUrbano.Domain.Interfaces.Repositories.UserRepository;

namespace SOSUrbano.Domain.Comands.UserTypeComands.List
{
    internal class ListUserTypesHandler
        (IRepositoryUserType repositoryUserType) :
        IRequestHandler<ListUserTypesRequest, ListUserTypesResponse>
    {
        public async Task<ListUserTypesResponse> Handle
            (ListUserTypesRequest request, CancellationToken cancellationToken)
        {
            var userTypes = await repositoryUserType.GetAllAsync();
            return new ListUserTypesResponse(userTypes);
        }
    }
}
