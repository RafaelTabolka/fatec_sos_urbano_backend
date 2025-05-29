using SOSUrbano.Domain.Entities.InstitutionEntity;

namespace SOSUrbano.Domain.Comands.ComandsInstitution.InstitutionTypeComands.Update
{
    public class UpdateInstitutionTypeResponse(string message)
    {
        public string Message { get; } = message;
    }
}
