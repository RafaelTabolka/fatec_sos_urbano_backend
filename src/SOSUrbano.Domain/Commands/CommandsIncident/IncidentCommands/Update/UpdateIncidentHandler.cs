using MediatR;
using SOSUrbano.Domain.Interfaces.Repositories.IncidentRepository;
using SOSUrbano.Domain.Interfaces.Repositories.InstitutionRepository;
using SOSUrbano.Domain.Interfaces.Services.GeoLocalizationService;
using ValidationException = FluentValidation.ValidationException;

namespace SOSUrbano.Domain.Commands.CommandsIncident.IncidentCommands.Update
{
    internal class UpdateIncidentHandler
        (IRepositoryIncident repositoryIncident,
        IRepositoryInstitution repositoryInstitution,
        IRepositoryIncidentStatus repositoryIncidentStatus,
        IGeoLozalizationService geoLozalizationService) :
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

            var json = await geoLozalizationService
                .GetAddressFromCoordinatesAsync(request.LatLocalization, request.LongLocalization);

            if (!json.TryGetProperty("address", out var address))
                throw new Exception("Endereço não encontrado");

            var road = address.TryGetProperty("road", out var roadValue)
                ? roadValue.ToString()
                : "null";

            var suburb = address.TryGetProperty("suburb", out var suburbValue)
                ? suburbValue.ToString()
                : "null";

            var fullAddress = $"{road}, {suburb}";

            incident.Description = request.Description;
            incident.LatLocalization = request.LatLocalization;
            incident.LongLocalization = request.LongLocalization;
            incident.Address = fullAddress;
            incident.InstitutionId = institution.Id;
            incident.IncidentStatusId = incidentStatus.Id;

            repositoryIncident.Update(incident);

            await repositoryIncident.CommitAsync();

            return new UpdateIncidentResponse("Atualizado com sucesso");
        }
    }
}
