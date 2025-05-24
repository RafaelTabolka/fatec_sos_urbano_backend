using SOSUrbano.Domain.Entities.InstitutionEntity;

namespace SOSUrbano.Domain.Comands.ComandsInstitution.InstitutionEmailComands.Update
{
    public class UpdateInstitutionEmailResponse
        (InstitutionEmail institutionEmail)
    {
        public InstitutionEmail InstitutionEmail { get; } = institutionEmail;
    }
}
