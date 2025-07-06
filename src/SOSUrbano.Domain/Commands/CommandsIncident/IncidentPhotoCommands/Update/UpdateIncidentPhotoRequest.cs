using MediatR;
using Microsoft.AspNetCore.Http;

namespace SOSUrbano.Domain.Commands.CommandsIncident.IncidentPhotoCommands.Update
{
    public class UpdateIncidentPhotoRequest :
        IRequest<UpdateIncidentPhotoResponse>
    {
        public Guid Id { get; set; }
        public IFormFile File { get; set; } = null!;
    }
}
    