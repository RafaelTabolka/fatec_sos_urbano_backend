using MediatR;
using SOSUrbano.Domain.Entities.InstitutionEntity;

namespace SOSUrbano.Domain.Comands.ComandsInstitution.InstitutionComands.Update
{
    public class UpdateInstitutionRequest :
        IRequest<UpdateInstitutionResponse>
    {
        public Guid Id { get; set; }
        
        public string Name { get; set; } = string.Empty;
        
        public string UrlSite { get; set; } = string.Empty;
        
        public string Description { get; set; } = string.Empty;
        
        public string Address { get; set; } = string.Empty;
    }
}
