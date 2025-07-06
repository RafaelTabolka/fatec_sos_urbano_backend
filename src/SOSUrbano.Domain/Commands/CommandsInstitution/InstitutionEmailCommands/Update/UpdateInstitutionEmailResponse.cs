using SOSUrbano.Domain.Entities.InstitutionEntity;

namespace SOSUrbano.Domain.Commands.CommandsInstitution.InstitutionEmailCommands.Update
{
    public class UpdateInstitutionEmailResponse(string message)
    {
        public string Message { get; } = message;
    }
}
