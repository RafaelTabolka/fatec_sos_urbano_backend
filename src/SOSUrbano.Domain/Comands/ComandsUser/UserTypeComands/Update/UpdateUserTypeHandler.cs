using MediatR;
using SOSUrbano.Domain.Interfaces.Repositories.UserRepository;

namespace SOSUrbano.Domain.Comands.ComandsUser.UserTypeComands.Update
{
    internal class UpdateUserTypeHandler
        (IRepositoryUserType repositoryUserType) :
        IRequestHandler<UpdateUserTypeRequest, UpdateUserTypeResponse>
    {
        public async Task<UpdateUserTypeResponse> Handle
            (UpdateUserTypeRequest request, CancellationToken cancellationToken)
        {
            var userType = await repositoryUserType.
                GetByIdAsync(request.Id);

            if (userType is null)
                throw new Exception("Tipo não encontrado.");

            userType.Name = request.Name;

            repositoryUserType.Update(userType);

            await repositoryUserType.CommitAsync();

            return new UpdateUserTypeResponse(userType);
        }
    }
}
