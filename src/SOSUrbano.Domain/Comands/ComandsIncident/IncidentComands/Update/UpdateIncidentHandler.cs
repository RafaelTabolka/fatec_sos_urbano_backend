using MediatR;
using SOSUrbano.Domain.Interfaces.Repositories.IncidentRepository;
using SOSUrbano.Domain.Interfaces.Repositories.InstitutionRepository;
using ValidationException = FluentValidation.ValidationException;

namespace SOSUrbano.Domain.Comands.ComandsIncident.IncidentComands.Update
{
    internal class UpdateIncidentHandler
        (IRepositoryIncident repositoryIncident,
        IRepositoryInstitution repositoryInstitution,
        IRepositoryIncidentStatus repositoryIncidentStatus) :
        IRequestHandler<UpdateIncidentRequest, UpdateIncidentResponse>
    {
        public async Task<UpdateIncidentResponse> Handle
            (UpdateIncidentRequest request, CancellationToken cancellationToken)
        {
            var validator = new UpdateIncidentValidation();

            var validationResult = validator.Validate(request);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var incident = await repositoryIncident.GetByIdAsync(request.Id);

            if (incident is null)
                throw new Exception("Denúncia não encontrada.");

            var institution = await repositoryInstitution
                .GetInstitutionByNameAsync(request.InstitutionName);

            var incidentStatus = await repositoryIncidentStatus
                .GetIncidentStatusByNameAsync(request.IncidentStatusName);

            incident.Description = request.Description;
            incident.LatLocalization = request.LatLocalization;
            incident.LongLocalization = request.LongLocalization;
            incident.InstitutionId = institution.Id;
            incident.IncidentStatusId = incidentStatus.Id;

            repositoryIncident.Update(incident);

            await repositoryIncident.CommitAsync();

            return new UpdateIncidentResponse("Atualizado com sucesso");
        }
    }
}
