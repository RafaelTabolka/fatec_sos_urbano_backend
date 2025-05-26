using MediatR;

namespace SOSUrbano.Domain.Comands.ComandsIncident.IncidentPhotoComands.Update
{
    public class UpdateIncidentPhotoRequest :
        IRequest<UpdateIncidentPhotoResponse>
    {
        public Guid Id { get; set; }
        public string SavedPath { get; set; } = string.Empty;
    }
}
