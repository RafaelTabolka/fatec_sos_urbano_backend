using MediatR;
using SOSUrbano.Domain.Entities.UserEntity;
using SOSUrbano.Domain.Interfaces.Repositories.UserRepository;
using ValidationException = FluentValidation.ValidationException;

namespace SOSUrbano.Domain.Commands.CommandsUser.UserTypeCommands.Create
{
    internal class CreateUserTypeHandler
        (IRepositoryUserType repositoryUserType) :
        IRequestHandler<CreateUserTypeRequest, CreateUserTypeResponse>
    {
        public async Task<CreateUserTypeResponse> Handle
            (CreateUserTypeRequest request, CancellationToken cancellationToken)
        {
            var validator = new CreateUserTypeValidation();

            var validationResult = validator.Validate(request);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var userType = new UserType(request.Name);
            await repositoryUserType.AddAsync(userType);
            await repositoryUserType.CommitAsync();

            return new CreateUserTypeResponse(
                userType.Id, "Tipo de usuário criado com sucesso");
        }
    }
}
