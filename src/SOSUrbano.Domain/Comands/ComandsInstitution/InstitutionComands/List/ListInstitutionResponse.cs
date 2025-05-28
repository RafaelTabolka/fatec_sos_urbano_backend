using SOSUrbano.Domain.Comands.ComandsInstitution.InstitutionComands.Dto;
using SOSUrbano.Domain.Entities.InstitutionEntity;

namespace SOSUrbano.Domain.Comands.ComandsInstitution.InstitutionComands.List
{
    public class ListInstitutionResponse
        (IEnumerable<DtoInstitutionResponse> institutionResponses)
    {
        public IReadOnlyCollection<DtoInstitutionResponse> InstitutionResponses { get; } =
            institutionResponses.ToList();
    }
}
