using MediatR;

namespace SOSUrbano.Domain.Commands.CommandsInstitution.InstitutionTypeCommands.Delete
{
    public class DeleteInstitutionTypeRequest(Guid id) :
        IRequest<DeleteInstitutionTypeResponse>
    {
        public Guid Id { get; set; } = id;
    }
}
