namespace SOSUrbano.Domain.Comands.ComandsInstitution.InstitutionEmailComands.Dto
{
    public class DtoInstitutionEmailResponse(string emailAddress)
    {
        public string EmailAddress { get; } = emailAddress;
    }
}
