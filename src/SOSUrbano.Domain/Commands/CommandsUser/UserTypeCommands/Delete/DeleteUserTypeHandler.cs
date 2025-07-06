using MediatR;
using SOSUrbano.Domain.Interfaces.Repositories.UserRepository;
using ValidationException = FluentValidation.ValidationException;

namespace SOSUrbano.Domain.Commands.CommandsUser.UserTypeCommands.Delete
{
    internal class DeleteUserTypeHandler
        (IRepositoryUserType repositoryUserType) :
        IRequestHandler<DeleteUserTypeRequest, DeleteUserTypeResponse>
    {
        public async Task<DeleteUserTypeResponse> Handle
            (DeleteUserTypeRequest request, CancellationToken cancellationToken)
        {
            var validator = new DeleteUserTypeValidation();

            var validationResult = validator.Validate(request);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var userType = await repositoryUserType.
                GetByIdAsync(request.Id);

            if (userType is null)
                throw new Exception("Tipo não encontrado");

            repositoryUserType.Delete(userType.Id);

            await repositoryUserType.CommitAsync();

            return new DeleteUserTypeResponse("Tipo excluído com sucesso");
        }
    }
}
