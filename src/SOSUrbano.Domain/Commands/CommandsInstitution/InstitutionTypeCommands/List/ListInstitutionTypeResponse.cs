using SOSUrbano.Domain.Entities.InstitutionEntity;

namespace SOSUrbano.Domain.Commands.CommandsInstitution.InstitutionTypeCommands.List
{
    public class ListInstitutionTypeResponse
        (IEnumerable<InstitutionType> institutionTypes)
    {
        public IReadOnlyCollection<InstitutionType> InstitutionTypes { get; } =
            institutionTypes.ToList();
    }
}
