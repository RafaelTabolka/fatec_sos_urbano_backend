namespace SOSUrbano.Domain.Comands.ComandsIncident.IncidentStatusComands.Create
{
    public class CreateIncidentStatusResponse(Guid id, string message)
    {
        public Guid Id { get; } = id;
        public string Message { get; } = message;
    }
}
