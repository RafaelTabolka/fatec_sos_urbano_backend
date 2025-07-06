using MediatR;
using SOSUrbano.Domain.Interfaces.Repositories.UserRepository;
using ValidationException = FluentValidation.ValidationException;

namespace SOSUrbano.Domain.Commands.CommandsUser.UserPhoneCommands.Update
{
    internal class UpdateUserPhoneHandler
        (IRepositoryUserPhone repositoryUserPhone) :
        IRequestHandler<UpdateUserPhoneRequest, UpdateUserPhoneResponse>
    {
        public async Task<UpdateUserPhoneResponse> Handle
            (UpdateUserPhoneRequest request, CancellationToken cancellationToken)
        {
            var validator = new UpdateUserPhoneValidation();

            var validationResult = validator.Validate(request);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var userPhone = await repositoryUserPhone.
                GetByIdAsync(request.Id);

            if (userPhone is null)
                throw new Exception("Telefone não encontrado");

            userPhone.Number = request.Number;

            repositoryUserPhone.Update(userPhone);

            await repositoryUserPhone.CommitAsync();

            return new UpdateUserPhoneResponse("Atualizado com sucesso");
        }
    }
}
