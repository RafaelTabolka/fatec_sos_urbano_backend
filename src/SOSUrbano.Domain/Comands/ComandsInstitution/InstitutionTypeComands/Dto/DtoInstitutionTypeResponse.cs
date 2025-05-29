namespace SOSUrbano.Domain.Comands.ComandsInstitution.InstitutionTypeComands.Dto
{
    public class DtoInstitutionTypeResponse(Guid id, string name)
    {
        public Guid Id { get; } = id;
        public string Name { get; } = name;
    }
}
