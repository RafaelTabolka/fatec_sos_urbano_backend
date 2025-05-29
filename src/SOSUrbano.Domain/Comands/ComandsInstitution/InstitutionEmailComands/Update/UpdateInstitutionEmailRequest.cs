using MediatR;

namespace SOSUrbano.Domain.Comands.ComandsInstitution.InstitutionEmailComands.Update
{
    public class UpdateInstitutionEmailRequest :
        IRequest<UpdateInstitutionEmailResponse>
    {
        public Guid Id { get; set; }
        public string EmailAddress { get; set; } = string.Empty;
    }
}
