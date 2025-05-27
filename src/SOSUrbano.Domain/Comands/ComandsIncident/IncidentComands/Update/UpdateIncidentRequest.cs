using MediatR;
using SOSUrbano.Domain.Comands.ComandsIncident.IncidentPhotoComands.Create;

namespace SOSUrbano.Domain.Comands.ComandsIncident.IncidentComands.Update
{
    public class UpdateIncidentRequest :
        IRequest<UpdateIncidentResponse>
    {
        public Guid Id { get; set; }
        public string Description { get; set; } = string.Empty;

        public double LatLocalization { get; set; }

        public double LongLocalization { get; set; }

        public string InstitutionName { get; set; } = string.Empty;

        public string IncidentStatusName { get; set; } = string.Empty;
    }
}
