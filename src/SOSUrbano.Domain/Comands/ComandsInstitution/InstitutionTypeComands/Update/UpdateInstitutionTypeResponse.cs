using SOSUrbano.Domain.Entities.InstitutionEntity;

namespace SOSUrbano.Domain.Comands.ComandsInstitution.InstitutionTypeComands.Update
{
    public class UpdateInstitutionTypeResponse(InstitutionType institutionType)
    {
        public InstitutionType InstitutionType { get; } = institutionType;
    }
}
