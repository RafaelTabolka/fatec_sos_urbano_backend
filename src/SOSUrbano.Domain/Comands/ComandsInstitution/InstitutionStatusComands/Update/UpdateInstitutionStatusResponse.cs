using SOSUrbano.Domain.Entities.InstitutionEntity;

namespace SOSUrbano.Domain.Comands.ComandsInstitution.InstitutionStatusComands.Update
{
    public class UpdateInstitutionStatusResponse(string message)
    {
        public string Message { get; } = message;
    }
}
