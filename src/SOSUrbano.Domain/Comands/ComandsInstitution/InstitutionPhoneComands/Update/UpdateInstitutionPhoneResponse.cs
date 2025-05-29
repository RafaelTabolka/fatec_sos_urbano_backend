using SOSUrbano.Domain.Entities.InstitutionEntity;

namespace SOSUrbano.Domain.Comands.ComandsInstitution.InstitutionPhoneComands.Update
{
    public class UpdateInstitutionPhoneResponse(string message)
    {
        public string Message { get; } = message;
    }
}
