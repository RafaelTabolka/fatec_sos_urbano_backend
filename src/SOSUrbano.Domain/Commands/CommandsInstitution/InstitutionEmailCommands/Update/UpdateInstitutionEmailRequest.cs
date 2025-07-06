using MediatR;

namespace SOSUrbano.Domain.Commands.CommandsInstitution.InstitutionEmailCommands.Update
{
    public class UpdateInstitutionEmailRequest :
        IRequest<UpdateInstitutionEmailResponse>
    {
        public Guid Id { get; set; }
        public string EmailAddress { get; set; } = string.Empty;
    }
}
