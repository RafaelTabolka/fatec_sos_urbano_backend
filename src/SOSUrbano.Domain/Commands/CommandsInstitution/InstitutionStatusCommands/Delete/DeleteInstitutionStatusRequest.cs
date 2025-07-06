using MediatR;

namespace SOSUrbano.Domain.Commands.CommandsInstitution.InstitutionStatusCommands.Delete
{
    public class DeleteInstitutionStatusRequest(Guid id) :
        IRequest<DeleteInstitutionStatusResponse>
    {
        public Guid Id { get; set; } = id;
    }
}
