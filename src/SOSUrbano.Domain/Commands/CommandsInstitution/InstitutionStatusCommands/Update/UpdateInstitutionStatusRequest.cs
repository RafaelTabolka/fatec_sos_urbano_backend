using MediatR;

namespace SOSUrbano.Domain.Commands.CommandsInstitution.InstitutionStatusCommands.Update
{
    public class UpdateInstitutionStatusRequest :
        IRequest<UpdateInstitutionStatusResponse>
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
