using MediatR;
using SOSUrbano.Domain.Interfaces.Repositories.UserRepository;
using ValidationException = FluentValidation.ValidationException;

namespace SOSUrbano.Domain.Commands.CommandsUser.UserTypeCommands.Update
{
    internal class UpdateUserTypeHandler
        (IRepositoryUserType repositoryUserType) :
        IRequestHandler<UpdateUserTypeRequest, UpdateUserTypeResponse>
    {
        public async Task<UpdateUserTypeResponse> Handle
            (UpdateUserTypeRequest request, CancellationToken cancellationToken)
        {
            var validator = new UpdateUserTypeValidation();

            var validationResult = validator.Validate(request);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors); 

            var userType = await repositoryUserType.
                GetByIdAsync(request.Id);

            if (userType is null)
                throw new Exception("Tipo não encontrado.");

            userType.Name = request.Name;

            repositoryUserType.Update(userType);

            await repositoryUserType.CommitAsync();

            return new UpdateUserTypeResponse("Atualizado com sucesso");
        }
    }
}
