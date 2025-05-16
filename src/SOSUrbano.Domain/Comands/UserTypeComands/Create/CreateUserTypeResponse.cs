namespace SOSUrbano.Domain.Comands.UserTypeComands.Create
{
    public class CreateUserTypeResponse(Guid id, string message)
    {
        public Guid Id { get; } = id;
        public string Message { get; } = message;
    }
}
