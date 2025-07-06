using SOSUrbano.Domain.Entities.InstitutionEntity;

namespace SOSUrbano.Domain.Commands.CommandsInstitution.InstitutionStatusCommands.List
{
    public class ListInstitutionStatusesResponse
        (IEnumerable<InstitutionStatus> institutionStatuses)
    {
        public IReadOnlyCollection<InstitutionStatus> InstitutionStatuses { get; } =
            institutionStatuses.ToList();
    }
}
