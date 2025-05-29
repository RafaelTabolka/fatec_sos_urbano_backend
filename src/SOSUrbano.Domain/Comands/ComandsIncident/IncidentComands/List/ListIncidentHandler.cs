using MediatR;
using SOSUrbano.Domain.Comands.ComandsIncident.IncidentComands.Dto;
using SOSUrbano.Domain.Comands.ComandsIncident.IncidentPhotoComands.Dto;
using SOSUrbano.Domain.Comands.ComandsIncident.IncidentStatusComands.Dto;
using SOSUrbano.Domain.Interfaces.Repositories.IncidentRepository;

namespace SOSUrbano.Domain.Comands.ComandsIncident.IncidentComands.List
{
    internal class ListIncidentHandler
        (IRepositoryIncident repositoryIncident) :
        IRequestHandler<ListIncidentRequest, ListIncidentResponse>
    {
        public async Task<ListIncidentResponse> Handle
            (ListIncidentRequest request, CancellationToken cancellationToken)
        {
            var incidents = await repositoryIncident.GetAllIncidentsAsync();

            var response = incidents.Select(i =>
            new DtoIncidentResponse(
                i.Id,
                i.Description,
                i.LatLocalization,
                i.LongLocalization,
                new DtoIncidentStatusResponse(i.Id, i.IncidentStatus.Name),
                i.IncidentPhotos.Select(photo =>
                new DtoIncidentPhotoResponse(photo.Id, photo.SavedPath)).ToList(),
                i.UserId,
                i.InstitutionId)).ToList();

            return new ListIncidentResponse(response);
        }
    }
}
