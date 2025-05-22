using SOSUrbano.Domain.Entities.Base;

namespace SOSUrbano.Domain.Entities.InstitutionEntity
{
    public class InstitutionEmail : EntityBase
    {
        public string EmailAddress { get; set; } = string.Empty;
        public Guid InstitutionId { get; set; }

        public InstitutionEmail(string emailAddress, Guid institutionId)
        {
            Id = Guid.NewGuid();
            EmailAddress = emailAddress;
            InstitutionId = institutionId;
        }
    }
}
