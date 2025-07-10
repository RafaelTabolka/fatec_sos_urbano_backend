using MediatR;
using SOSUrbano.Domain.Commands.CommandsIncident.IncidentCommands.Dto;
using SOSUrbano.Domain.Commands.CommandsIncident.IncidentPhotoCommands.Dto;
using SOSUrbano.Domain.Commands.CommandsIncident.IncidentStatusCommands.Dto;
using SOSUrbano.Domain.Entities.IncidentEntity;
using SOSUrbano.Domain.Interfaces.Repositories.IncidentRepository;
using SOSUrbano.Domain.Interfaces.Repositories.InstitutionRepository;
using SOSUrbano.Domain.Interfaces.Services.FileService;
using SOSUrbano.Domain.Interfaces.Services.GeoLocalizationService;
using ValidationException = FluentValidation.ValidationException;

namespace SOSUrbano.Domain.Commands.CommandsIncident.IncidentCommands.Create
{
    internal class CreateIncidentHandler
        (IRepositoryIncident repositoryIncident,
        IRepositoryIncidentStatus repositoryIncidentStatus,
        IRepositoryInstitution repositoryInstitution,
        IFileService fileService,
        IGeoLozalizationService geoLozalizationService) :
        IRequestHandler<CreateIncidentRequest, CreateIncidentResponse>
    {
        public async Task<CreateIncidentResponse> Handle
            (CreateIncidentRequest request, CancellationToken cancellationToken)
        {
            var validator = new CreateIncidentValidation();
            var validationResult = validator.Validate(request);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

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

            var incident = new Incident(
                request.Description,
                request.LatLocalization,
                request.LongLocalization,
                fullAddress,
                institution.Id,
                incidentStatus.Id,
                request.UserId
                );

            var filesPhoto = request.IncidentPhotoRequest
                .Select(file => file).ToList();

            var paths = await fileService.CreatePathPhotosAsync(filesPhoto);

            incident.IncidentPhotos = paths
                .Select(savedPath => new IncidentPhoto(
                    savedPath, 
                    incident.Id)).ToList();

            await repositoryIncident.AddAsync(incident);
            await repositoryIncident.CommitAsync();

            var response = new DtoIncidentResponse(
                incident.Id,
                incident.Description,
                incident.LatLocalization,
                incident.LongLocalization,
                incident.Address,
                new DtoIncidentStatusResponse(
                    incident.IncidentStatusId, 
                    incident.IncidentStatus.Name),
                incident.IncidentPhotos.Select(photo => 
                    new DtoIncidentPhotoResponse(
                        incident.Id, 
                        photo.SavedPath)).ToList(),
                incident.UserId,
                incident.InstitutionId);

            return new CreateIncidentResponse(response);
        }
    }
}
