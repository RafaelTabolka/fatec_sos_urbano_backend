using MediatR;

namespace SOSUrbano.Domain.Commands.CommandsInstitution.InstitutionCommands.Update
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
