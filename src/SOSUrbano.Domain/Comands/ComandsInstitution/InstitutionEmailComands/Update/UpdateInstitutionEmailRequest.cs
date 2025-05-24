using MediatR;

namespace SOSUrbano.Domain.Comands.ComandsInstitution.InstitutionEmailComands.Update
{
    public class UpdateInstitutionEmailRequest(Guid id) :
        IRequest<UpdateInstitutionEmailResponse>
    {
        public Guid Id { get; set; } = id;
        public string EmailAddress { get; set; } = string.Empty;
    }
}
