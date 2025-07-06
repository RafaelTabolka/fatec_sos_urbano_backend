using MediatR;
using Microsoft.AspNetCore.Http;

namespace SOSUrbano.Domain.Commands.CommandsIncident.IncidentCommands.Create
{
    public class CreateIncidentRequest :
        IRequest<CreateIncidentResponse>
    {
        public string Description { get; set; } = string.Empty;

        public double LatLocalization { get; set; }

        public double LongLocalization { get; set; }

        public List<IFormFile> IncidentPhotoRequest { get; set; } = null!;

        public string InstitutionName { get; set; } = string.Empty;

        public string IncidentStatusName { get; set; } = string.Empty;
       
        public Guid UserId { get; set; }
    }
}
