using MediatR;
using SOSUrbano.Domain.Entities.IncidentEntity;
using SOSUrbano.Domain.Interfaces.Repositories.IncidentRepository;
using SOSUrbano.Domain.Interfaces.Repositories.InstitutionRepository;

namespace SOSUrbano.Domain.Comands.ComandsIncident.IncidentComands.Create
{
    internal class CreateIncidentHandler
        (IRepositoryIncident repositoryIncident,
        IRepositoryIncidentStatus repositoryIncidentStatus,
        IRepositoryInstitution repositoryInstitution) :
        IRequestHandler<CreateIncidentRequest, CreateIncidentResponse>
    {
        public async Task<CreateIncidentResponse> Handle
            (CreateIncidentRequest request, CancellationToken cancellationToken)
        {
            var institution = await repositoryInstitution
                .GetInstitutionByNameAsync(request.InstitutionName);

            var incidentStatus = await repositoryIncidentStatus
                .GetIncidentStatusByNameAsync(request.IncidentStatusName);

            var incident = new Incident(
                request.Description,
                request.LatLocalization,
                request.LongLocalization,
                institution.Id,
                incidentStatus.Id,
                request.UserId
                );

            incident.IncidentPhotos = request.IncidentPhotoRequest
                .Select(photo => new IncidentPhoto
                (photo.SavedPath, incident.Id)).ToList();

            await repositoryIncident.AddAsync(incident);
            await repositoryIncident.CommitAsync();

            return new CreateIncidentResponse(incident.Id,
                incident.Description, incident.Institution.Name,
                incident.IncidentStatus.Name, incident.LatLocalization,
                incident.LongLocalization, incident.IncidentPhotos,
                incident.UserId);
        }
    }
}
