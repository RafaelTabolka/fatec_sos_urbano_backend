    using MediatR;
    using SOSUrbano.Domain.Interfaces.Repositories.IncidentRepository;
    using SOSUrbano.Domain.Interfaces.Services.FileService;

    namespace SOSUrbano.Domain.Commands.CommandsIncident.IncidentPhotoCommands.Update
    {
        internal class UpdateIncidentPhotoHandler
            (IRepositoryIncidentPhoto repositoryIncidentPhoto,
            IFileService fileService) :
            IRequestHandler<UpdateIncidentPhotoRequest, UpdateIncidentPhotoResponse>
        {
            public async Task<UpdateIncidentPhotoResponse> Handle
                (UpdateIncidentPhotoRequest request, CancellationToken cancellationToken)
            {
                var incidentPhoto = await repositoryIncidentPhoto.
                    GetByIdAsync(request.Id);

                if (incidentPhoto is null)
                    throw new Exception("Foto não encontrada.");

                var oldPath = Path.Combine("wwwroot", incidentPhoto.SavedPath ?? "");

                /*
                 Por precaução verifica se o arquivo existe e o deleta para que não
                tenha consumo desnecessário de disco no servidor.
                 */
                if (File.Exists(oldPath))
                    File.Delete(oldPath);

                var path = await fileService.UpdatePathPhotoAsync(request.File);

                incidentPhoto.SavedPath = path;

                repositoryIncidentPhoto.Update(incidentPhoto);

                await repositoryIncidentPhoto.CommitAsync();

                return new UpdateIncidentPhotoResponse("Atualizado com sucesso");
            }
        }
    }
