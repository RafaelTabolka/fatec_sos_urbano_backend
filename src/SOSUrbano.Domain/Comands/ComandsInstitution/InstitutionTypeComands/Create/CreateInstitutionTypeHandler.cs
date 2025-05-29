using MediatR;
using SOSUrbano.Domain.Entities.InstitutionEntity;
using SOSUrbano.Domain.Interfaces.Repositories.InstitutionRepository;
using ValidationException = FluentValidation.ValidationException;

namespace SOSUrbano.Domain.Comands.ComandsInstitution.InstitutionTypeComands.Create
{
    public class CreateInstitutionTypeHandler
        (IRepositoryInstitutionType repositoryInstitutionType) :
        IRequestHandler<CreateInstitutionTypeRequest, CreateInstitutionTypeResponse>
    {
        public async Task<CreateInstitutionTypeResponse> Handle
            (CreateInstitutionTypeRequest request, CancellationToken cancellationToken)
        {
            var validator = new CreateInstitutionTypeValidation();

            var validationResult = validator.Validate(request);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var entityType = new InstitutionType(request.Name);

            await repositoryInstitutionType.AddAsync(entityType);
            await repositoryInstitutionType.CommitAsync();

            return new CreateInstitutionTypeResponse(entityType.Id);

        }
    }
}
