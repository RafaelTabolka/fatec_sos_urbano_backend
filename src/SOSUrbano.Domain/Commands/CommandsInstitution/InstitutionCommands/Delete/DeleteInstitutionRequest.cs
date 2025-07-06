using MediatR;

namespace SOSUrbano.Domain.Commands.CommandsInstitution.InstitutionCommands.Delete
{
    public class DeleteInstitutionRequest (Guid id) :
        IRequest<DeleteInstitutionResponse>
    {
        public Guid Id { get; set; } = id;
    }
}
