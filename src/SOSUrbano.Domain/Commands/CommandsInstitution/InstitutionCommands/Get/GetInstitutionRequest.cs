using MediatR;

namespace SOSUrbano.Domain.Commands.CommandsInstitution.InstitutionCommands.Get
{
    public class GetInstitutionRequest(Guid id) :
        IRequest<GetInstitutionResponse>
    {
        public Guid Id { get; set; } = id;
    }
}
