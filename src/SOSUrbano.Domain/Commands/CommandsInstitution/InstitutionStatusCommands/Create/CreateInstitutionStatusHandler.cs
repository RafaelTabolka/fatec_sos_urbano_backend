using MediatR;
using SOSUrbano.Domain.Entities.InstitutionEntity;
using SOSUrbano.Domain.Interfaces.Repositories.InstitutionRepository;
using ValidationException = FluentValidation.ValidationException;

namespace SOSUrbano.Domain.Commands.CommandsInstitution.InstitutionStatusCommands.Create
{
    public class CreateInstitutionStatusHandler
        (IRepositoryInstitutionStatus repositoryInstitutionStatus):
        IRequestHandler<CreateInstitutionStatusRequest, CreateInstitutionStatusResponse>
    {
        public async Task<CreateInstitutionStatusResponse> 
            Handle(CreateInstitutionStatusRequest request, CancellationToken cancellationToken)
        {
            var validator = new CreateInstitutionStatusValidation();

            var validationResult = validator.Validate(request);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var entityStatus = new InstitutionStatus(request.Name);

            await repositoryInstitutionStatus.AddAsync(entityStatus);
            await repositoryInstitutionStatus.CommitAsync();

            return new CreateInstitutionStatusResponse(entityStatus.Id);
        }
    }
}
