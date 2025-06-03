using MediatR;
using SOSUrbano.Domain.Comands.ComandsIncident.IncidentComands.Dto;
using SOSUrbano.Domain.Comands.ComandsIncident.IncidentPhotoComands.Dto;
using SOSUrbano.Domain.Comands.ComandsIncident.IncidentStatusComands.Dto;
using SOSUrbano.Domain.Entities.IncidentEntity;
using SOSUrbano.Domain.Interfaces.Repositories.IncidentRepository;
using SOSUrbano.Domain.Interfaces.Repositories.InstitutionRepository;
using SOSUrbano.Domain.Interfaces.Services.FileService;
using ValidationException = FluentValidation.ValidationException;

namespace SOSUrbano.Domain.Comands.ComandsIncident.IncidentComands.Create
{
    internal class CreateIncidentHandler
        (IRepositoryIncident repositoryIncident,
        IRepositoryIncidentStatus repositoryIncidentStatus,
        IRepositoryInstitution repositoryInstitution,
        IFileService fileService) :
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

            var incident = new Incident(
                request.Description,
                request.LatLocalization,
                request.LongLocalization,
                institution.Id,
                incidentStatus.Id,
                request.UserId
                );

            var filesPhoto = request.IncidentPhotoRequest
                .Select(file => file).ToList();

            var paths = await fileService.CreatePathPhotosAsync(filesPhoto);

            /*
             Zip junta os arquivos na mesma ordem em que são criados. Nesse caso
            o que acontece é o seguinte, pega cada caminho encontrado na variável
            paths e junta com cada arquivo mandado na requisição contido na 
            variável files. Ai vai juntar 
             */

            //incident.IncidentPhotos = request.IncidentPhotoRequest
            //    .Zip(paths, (fileRequest, savedPath) => new IncidentPhoto(
            //        savedPath, 
            //        incident.Id)).ToList();

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
                new DtoIncidentStatusResponse(
                    incident.Id, 
                    incident.IncidentStatus.Name),
                incident.IncidentPhotos.Select(photo => 
                    new DtoIncidentPhotoResponse(
                        incident.Id, 
                        photo.SavedPath)).ToList(),
                incident.Id,
                incident.InstitutionId);

            return new CreateIncidentResponse(response);
        }
    }
}
