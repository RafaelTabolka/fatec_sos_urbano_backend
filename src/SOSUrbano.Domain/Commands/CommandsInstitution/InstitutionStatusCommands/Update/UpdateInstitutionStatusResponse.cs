using SOSUrbano.Domain.Entities.InstitutionEntity;

namespace SOSUrbano.Domain.Commands.CommandsInstitution.InstitutionStatusCommands.Update
{
    public class UpdateInstitutionStatusResponse(string message)
    {
        public string Message { get; } = message;
    }
}
