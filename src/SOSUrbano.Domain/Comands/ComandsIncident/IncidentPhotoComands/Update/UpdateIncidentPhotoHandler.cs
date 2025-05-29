using MediatR;
using SOSUrbano.Domain.Interfaces.Repositories.IncidentRepository;

namespace SOSUrbano.Domain.Comands.ComandsIncident.IncidentPhotoComands.Update
{
    internal class UpdateIncidentPhotoHandler
        (IRepositoryIncidentPhoto repositoryIncidentPhoto) :
        IRequestHandler<UpdateIncidentPhotoRequest, UpdateIncidentPhotoResponse>
    {
        public async Task<UpdateIncidentPhotoResponse> Handle
            (UpdateIncidentPhotoRequest request, CancellationToken cancellationToken)
        {
            var incidentPhoto = await repositoryIncidentPhoto.
                GetByIdAsync(request.Id);

            if (incidentPhoto is null)
                throw new Exception("Foto não encontrada.");

            incidentPhoto.SavedPath = request.SavedPath;

            repositoryIncidentPhoto.Update(incidentPhoto);

            await repositoryIncidentPhoto.CommitAsync();

            return new UpdateIncidentPhotoResponse("Atualizado com sucesso");
        }
    }
}
