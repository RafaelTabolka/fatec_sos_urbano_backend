using MediatR;
using Microsoft.AspNetCore.Http;

namespace SOSUrbano.Domain.Comands.ComandsIncident.IncidentPhotoComands.Update
{
    public class UpdateIncidentPhotoRequest :
        IRequest<UpdateIncidentPhotoResponse>
    {
        public Guid Id { get; set; }
        public IFormFile File { get; set; } = null!;
    }
}
