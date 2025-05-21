using SOSUrbano.Domain.Entities.Base;

namespace SOSUrbano.Domain.Entities.InstitutionEntity
{
    public class InstitutionStatus : EntityBase
    {
        public string Name { get; set; } = string.Empty;

        public InstitutionStatus(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
        }
    }
}
