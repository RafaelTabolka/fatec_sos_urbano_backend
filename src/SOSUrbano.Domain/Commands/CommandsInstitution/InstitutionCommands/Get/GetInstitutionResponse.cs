using SOSUrbano.Domain.Commands.CommandsInstitution.InstitutionCommands.Dto;
using SOSUrbano.Domain.Entities.InstitutionEntity;

namespace SOSUrbano.Domain.Commands.CommandsInstitution.InstitutionCommands.Get
{
    public class GetInstitutionResponse(DtoInstitutionResponse institutionResponse)
    {
        public DtoInstitutionResponse InstitutionResponse { get; } = institutionResponse;
    }
}
