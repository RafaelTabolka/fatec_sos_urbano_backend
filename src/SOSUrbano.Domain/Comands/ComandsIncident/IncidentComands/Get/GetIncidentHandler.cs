using MediatR;
using SOSUrbano.Domain.Comands.ComandsIncident.IncidentComands.Dto;
using SOSUrbano.Domain.Comands.ComandsIncident.IncidentPhotoComands.Dto;
using SOSUrbano.Domain.Comands.ComandsIncident.IncidentStatusComands.Dto;
using SOSUrbano.Domain.Interfaces.Repositories.IncidentRepository;

namespace SOSUrbano.Domain.Comands.ComandsIncident.IncidentComands.Get
{
    internal class GetIncidentHandler
        (IRepositoryIncident repositoryIncident) :
        IRequestHandler<GetIncidentRequest, GetIncidentResponse>
    {
        public async Task<GetIncidentResponse> Handle
            (GetIncidentRequest request, CancellationToken cancellationToken)
        {
            var incident = await repositoryIncident.GetIncidentByIdAsync(request.Id);

            if (incident is null)
                throw new Exception("Denúncia não encontrada.");

            var response = new DtoIncidentResponse(
                incident.Id,
                incident.Description,
                incident.LatLocalization,
                incident.LongLocalization,
                new DtoIncidentStatusResponse(incident.IncidentStatus.Name),
                incident.IncidentPhotos.Select(photo =>
                new DtoIncidentPhotoResponse(photo.SavedPath)).ToList(),
                incident.UserId,
                incident.InstitutionId);

            return new GetIncidentResponse(response); 
        }
    }
}
