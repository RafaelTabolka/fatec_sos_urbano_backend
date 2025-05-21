using SOSUrbano.Domain.Entities.Base;

namespace SOSUrbano.Domain.Entities.InstitutionEntity
{
    public class InstitutionType : EntityBase
    {
        public string Name { get; set; } = string.Empty;

        public InstitutionType(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
        }
    }
}
