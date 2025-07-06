using SOSUrbano.Domain.Entities.InstitutionEntity;

namespace SOSUrbano.Domain.Commands.CommandsInstitution.InstitutionPhoneCommands.Update
{
    public class UpdateInstitutionPhoneResponse(string message)
    {
        public string Message { get; } = message;
    }
}
