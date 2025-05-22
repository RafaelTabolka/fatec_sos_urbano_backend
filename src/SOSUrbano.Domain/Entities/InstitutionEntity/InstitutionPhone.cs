using SOSUrbano.Domain.Entities.Base;

namespace SOSUrbano.Domain.Entities.InstitutionEntity
{
    public class InstitutionPhone : EntityBase
    {
        public string Number { get; set; } = string.Empty;
        public Guid InstitutionId { get; set; }

        public InstitutionPhone(string number, Guid institutionId)
        {
            Number = number;
            InstitutionId = institutionId;
        }
    }
}
