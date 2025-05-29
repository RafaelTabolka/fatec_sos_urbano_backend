using MediatR;
using SOSUrbano.Domain.Interfaces.Repositories.IncidentRepository;
using ValidationException = FluentValidation.ValidationException;

namespace SOSUrbano.Domain.Comands.ComandsIncident.IncidentStatusComands.Update
{
    internal class UpdateIncidentStatusHandler
        (IRepositoryIncidentStatus repositoryIncidentStatus) :
        IRequestHandler<UpdateIncidentStatusRequest, UpdateIncidentStatusResponse>
    {
        public async Task<UpdateIncidentStatusResponse> Handle
            (UpdateIncidentStatusRequest request, CancellationToken cancellationToken)
        {
            var validator = new UpdateIncidentStatusValidation();

            var validationResult = validator.Validate(request);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var incidentStatus = await repositoryIncidentStatus.
                GetByIdAsync(request.Id);

            if (incidentStatus is null)
                throw new Exception("Status não encontrado");

            incidentStatus.Name = request.Name;

            repositoryIncidentStatus.Update(incidentStatus);

            await repositoryIncidentStatus.CommitAsync();

            return new UpdateIncidentStatusResponse("Atualizado com sucesso");
        }
    }
}
