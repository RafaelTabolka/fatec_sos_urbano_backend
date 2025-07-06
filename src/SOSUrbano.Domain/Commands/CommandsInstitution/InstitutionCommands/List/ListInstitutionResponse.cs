using SOSUrbano.Domain.Commands.CommandsInstitution.InstitutionCommands.Dto;
using SOSUrbano.Domain.Entities.InstitutionEntity;

namespace SOSUrbano.Domain.Commands.CommandsInstitution.InstitutionCommands.List
{
    public class ListInstitutionResponse
        (IEnumerable<DtoInstitutionResponse> institutionResponses)
    {
        public IReadOnlyCollection<DtoInstitutionResponse> InstitutionResponses { get; } =
            institutionResponses.ToList();
    }
}
