using SOSUrbano.Domain.Entities.InstitutionEntity;

namespace SOSUrbano.Domain.Comands.ComandsInstitution.InstitutionComands.Get
{
    public class GetInstitutionResponse(Institution institution)
    {
        public Institution Institution { get; } = institution;
    }
}
