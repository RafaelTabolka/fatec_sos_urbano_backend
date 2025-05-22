using SOSUrbano.Domain.Entities.InstitutionEntity;

namespace SOSUrbano.Domain.Comands.ComandsInstitution.InstitutionComands.List
{
    public class ListInstitutionResponse(IEnumerable<Institution> institutions)
    {
        public IReadOnlyCollection<Institution> Institutions { get; } =
            institutions.ToList();
    }
}
