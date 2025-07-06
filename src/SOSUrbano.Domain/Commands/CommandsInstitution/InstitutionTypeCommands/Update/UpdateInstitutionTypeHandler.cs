using MediatR;
using SOSUrbano.Domain.Interfaces.Repositories.InstitutionRepository;
using ValidationException = FluentValidation.ValidationException;

namespace SOSUrbano.Domain.Commands.CommandsInstitution.InstitutionTypeCommands.Update
{
    internal class UpdateInstitutionTypeHandler
        (IRepositoryInstitutionType repositoryInstitutionType) :
        IRequestHandler<UpdateInstitutionTypeRequest, UpdateInstitutionTypeResponse>
    {
        public async Task<UpdateInstitutionTypeResponse> Handle
            (UpdateInstitutionTypeRequest request, CancellationToken cancellationToken)
        {
            var validator = new UpdateInstitutionTypeValidation();

            var validationResult = validator.Validate(request);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);


            var institutionType = await repositoryInstitutionType.GetByIdAsync(request.Id);

            if (institutionType is null)
                throw new Exception("Tipo não encontrado.");

            institutionType.Name = request.Name;

            repositoryInstitutionType.Update(institutionType);

            await repositoryInstitutionType.CommitAsync();

            return new UpdateInstitutionTypeResponse("Atualizado com sucesso");
        }
    }
}
