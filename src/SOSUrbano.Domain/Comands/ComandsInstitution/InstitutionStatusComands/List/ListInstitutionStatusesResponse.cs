using SOSUrbano.Domain.Entities.InstitutionEntity;

namespace SOSUrbano.Domain.Comands.ComandsInstitution.InstitutionStatusComands.List
{
    public class ListInstitutionStatusesResponse
        (IEnumerable<InstitutionStatus> institutionStatuses)
    {
        public IReadOnlyCollection<InstitutionStatus> InstitutionStatuses { get; } =
            institutionStatuses.ToList();
    }
}
