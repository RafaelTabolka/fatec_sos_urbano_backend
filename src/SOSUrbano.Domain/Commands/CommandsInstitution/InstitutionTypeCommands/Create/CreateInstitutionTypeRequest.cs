using MediatR;

namespace SOSUrbano.Domain.Commands.CommandsInstitution.InstitutionTypeCommands.Create
{
    public class CreateInstitutionTypeRequest :
        IRequest<CreateInstitutionTypeResponse>
    {
        public string Name { get; set; } = string.Empty;
    }
}
