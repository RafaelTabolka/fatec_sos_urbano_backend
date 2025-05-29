using MediatR;
using SOSUrbano.Domain.Interfaces.Repositories.InstitutionRepository;
using ValidationException = FluentValidation.ValidationException;

namespace SOSUrbano.Domain.Comands.ComandsInstitution.InstitutionStatusComands.Update
{
    internal class UpdateInstitutionStatusHandler
        (IRepositoryInstitutionStatus repositoryInstitutionStatus) :
        IRequestHandler<UpdateInstitutionStatusRequest, UpdateInstitutionStatusResponse>
    {
        public async Task<UpdateInstitutionStatusResponse> Handle
            (UpdateInstitutionStatusRequest request, CancellationToken cancellationToken)
        {
            var validator = new UpdateInstitutionStatusValidation();

            var validationResult = validator.Validate(request);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var institutionStatus = await repositoryInstitutionStatus.
                GetByIdAsync(request.Id);

            if (institutionStatus is null)
                throw new Exception("Status não encontrado.");

            institutionStatus.Name = request.Name;

            repositoryInstitutionStatus.Update(institutionStatus);

            await repositoryInstitutionStatus.CommitAsync();

            return new UpdateInstitutionStatusResponse("Atualizado com sucesso");
        }
    }
}
