namespace SOSUrbano.Domain.Comands.ComandsUser.UserTypeComands.Create
{
    public class CreateUserTypeResponse(Guid id, string message)
    {
        public Guid Id { get; } = id;
        public string Message { get; } = message;
    }
}
