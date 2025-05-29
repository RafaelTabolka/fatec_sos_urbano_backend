using SOSUrbano.Domain.Entities.InstitutionEntity;

namespace SOSUrbano.Domain.Comands.ComandsInstitution.InstitutionComands.Update
{
    public class UpdateInstitutionResponse(string message)
    {
        public string Message { get; } = message;
    }
}
