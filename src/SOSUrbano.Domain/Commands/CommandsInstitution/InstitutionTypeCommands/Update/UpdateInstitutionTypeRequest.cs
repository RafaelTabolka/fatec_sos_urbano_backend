using MediatR;

namespace SOSUrbano.Domain.Commands.CommandsInstitution.InstitutionTypeCommands.Update
{
    public class UpdateInstitutionTypeRequest :
        IRequest<UpdateInstitutionTypeResponse>
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = string.Empty;
    }
}
