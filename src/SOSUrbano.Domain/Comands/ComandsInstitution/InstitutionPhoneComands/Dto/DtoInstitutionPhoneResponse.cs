namespace SOSUrbano.Domain.Comands.ComandsInstitution.InstitutionPhoneComands.Dto
{
    public class DtoInstitutionPhoneResponse(Guid id, string number)
    {
        public Guid Id { get; } = id;
        public string Number { get; } = number;
    }
}
