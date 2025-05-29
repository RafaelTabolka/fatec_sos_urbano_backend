namespace SOSUrbano.Domain.Comands.ComandsIncident.IncidentStatusComands.Dto
{
    public class DtoIncidentStatusResponse(Guid id, string name)
    {
        public Guid Id { get; } = id;
        public string Name { get; } = name;
    }
}
