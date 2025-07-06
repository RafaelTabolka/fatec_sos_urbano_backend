using SOSUrbano.Domain.Entities.InstitutionEntity;

namespace SOSUrbano.Domain.Commands.CommandsInstitution.InstitutionTypeCommands.Update
{
    public class UpdateInstitutionTypeResponse(string message)
    {
        public string Message { get; } = message;
    }
}
