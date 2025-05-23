using SOSUrbano.Domain.Entities.InstitutionEntity;

namespace SOSUrbano.Domain.Comands.ComandsInstitution.InstitutionComands.Update
{
    public class UpdateInstitutionResponse(Institution institution)
    {
        public Institution Institution { get; } = institution;
    }
}
