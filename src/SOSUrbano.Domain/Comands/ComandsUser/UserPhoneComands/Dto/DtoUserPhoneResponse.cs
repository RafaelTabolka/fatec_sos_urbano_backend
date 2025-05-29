namespace SOSUrbano.Domain.Comands.ComandsUser.UserPhoneComands.Dto
{
    public class DtoUserPhoneResponse(Guid id, string number)
    {
        public Guid Id { get; } = id;
        public string Number { get; } = number;
    }
}
