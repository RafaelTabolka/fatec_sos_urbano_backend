using MediatR;
using SOSUrbano.Domain.Interfaces.Repositories.UserRepository;
using ValidationException = FluentValidation.ValidationException;

namespace SOSUrbano.Domain.Commands.CommandsUser.UserCommands.Update
{
    internal class UpdateUserHandler
        (IRepositoryUser repositoryUser,
        IRepositoryUserStatus repositoryUserStatus,
        IRepositoryUserType repositoryUserType) :
        IRequestHandler<UpdateUserRequst, UpdateUserResponse>
    {
        public async Task<UpdateUserResponse> Handle
            (UpdateUserRequst request, CancellationToken cancellationToken)
        {
            var validator = new UpdateUserValidation();

            var validationResult = validator.Validate(request);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            if (await repositoryUser.ThisEmailExist(request.Email))
                throw new Exception("Email ja está em uso.");

            var user = await repositoryUser.GetByIdAsync(request.Id);

            if (user is null)
                throw new Exception("Usuário não encontrado");

            var userStatus = await repositoryUserStatus.GetByStatusAsync
                (request.UserStatusName);

            var userType = await repositoryUserType.GetByTypeAsync
                (request.UserTypeName);

            user.Name = request.Name;
            user.Email = request.Email;
            user.Cpf = request.Cpf;
            user.UserStatusId = userStatus.Id;
            user.UserTypeId = userType.Id;

            repositoryUser.Update(user);
            await repositoryUser.CommitAsync();

            return new UpdateUserResponse("Atualizado com sucesso");
        }
    }
}
