using MediatR;

namespace SOSUrbano.Domain.Commands.CommandsInstitution.InstitutionStatusCommands.Create
{
    public class CreateInstitutionStatusRequest :
        IRequest<CreateInstitutionStatusResponse>
    {
        public string Name { get; set; } = string.Empty;
    }
}
