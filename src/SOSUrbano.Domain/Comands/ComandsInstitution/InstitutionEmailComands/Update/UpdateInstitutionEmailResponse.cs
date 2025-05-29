using SOSUrbano.Domain.Entities.InstitutionEntity;

namespace SOSUrbano.Domain.Comands.ComandsInstitution.InstitutionEmailComands.Update
{
    public class UpdateInstitutionEmailResponse(string message)
    {
        public string Message { get; } = message;
    }
}
