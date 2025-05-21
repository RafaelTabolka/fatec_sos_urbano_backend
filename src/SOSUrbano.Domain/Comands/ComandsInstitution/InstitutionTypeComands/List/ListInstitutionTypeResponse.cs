using SOSUrbano.Domain.Entities.InstitutionEntity;

namespace SOSUrbano.Domain.Comands.ComandsInstitution.InstitutionTypeComands.List
{
    public class ListInstitutionTypeResponse
        (IEnumerable<InstitutionType> institutionTypes)
    {
        public IReadOnlyCollection<InstitutionType> InstitutionTypes { get; } =
            institutionTypes.ToList();
    }
}
