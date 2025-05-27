using MediatR;
using SOSUrbano.Domain.Comands.ComandsIncident.IncidentPhotoComands.Create;

namespace SOSUrbano.Domain.Comands.ComandsIncident.IncidentComands.Create
{
    public class CreateIncidentRequest :
        IRequest<CreateIncidentResponse>
    {
        public string Description { get; set; } = string.Empty;

        public double LatLocalization { get; set; }

        public double LongLocalization { get; set; }

        public List<CreateIncidentPhotoRequest> IncidentPhotoRequest { get; set; } = null!;

        public string InstitutionName { get; set; } = string.Empty;

        public string IncidentStatusName { get; set; } = string.Empty;
       
        public Guid UserId { get; set; }
    }
}
