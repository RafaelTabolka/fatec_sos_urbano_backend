namespace SOSUrbano.Domain.Comands.ComandsUser.UserStatusComands.Dto
{
    public class DtoUserStatusResponse(Guid id, string name)
    {
        public Guid Id { get; } = id;
        public string Name { get; } = name;
    }
}
