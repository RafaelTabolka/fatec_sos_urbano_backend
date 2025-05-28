using SOSUrbano.Domain.Comands.ComandsInstitution.InstitutionComands.Dto;
using SOSUrbano.Domain.Entities.InstitutionEntity;

namespace SOSUrbano.Domain.Comands.ComandsInstitution.InstitutionComands.Get
{
    public class GetInstitutionResponse(DtoInstitutionResponse institutionResponse)
    {
        public DtoInstitutionResponse InstitutionResponse { get; } = institutionResponse;
    }
}
