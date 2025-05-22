namespace SOSUrbano.Domain.Comands.ComandsInstitution.InstitutionComands.Create
{
    public class CreateInstitutionResponse(Guid id, string message)
    {
        public Guid Id { get; } = id;
        public string Name { get; } = message;
    }
}
