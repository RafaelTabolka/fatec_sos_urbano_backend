using SOSUrbano.Domain.Entities.InstitutionEntity;

namespace SOSUrbano.Domain.Comands.ComandsInstitution.InstitutionStatusComands.Update
{
    public class UpdateInstitutionStatusResponse 
        (InstitutionStatus institutionStatus)
    {
        public InstitutionStatus InstitutionStatus { get; } =
            institutionStatus;
    }
}
