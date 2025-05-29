using MediatR;
using SOSUrbano.Domain.Entities.UserEntity;
using SOSUrbano.Domain.Interfaces.Repositories.UserRepository;
using ValidationException = FluentValidation.ValidationException;

namespace SOSUrbano.Domain.Comands.ComandsUser.UserStatusComands.Create
{
    internal class CreateUserStatusHandler
        (IRepositoryUserStatus repository) :
        IRequestHandler<CreateUserStatusRequest, CreateUserStatusResponse>
    {
        public async Task<CreateUserStatusResponse> Handle
            (CreateUserStatusRequest request, CancellationToken cancellationToken)
        {
            var validator = new CreateUserStatusValidation();

            var validationResult = validator.Validate(request);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var userStatus = new UserStatus(request.Name);
            await repository.AddAsync(userStatus);
            await repository.CommitAsync();

            return new CreateUserStatusResponse(userStatus.Id, "Status criado com sucesso");

        }
    }
}
