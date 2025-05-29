using MediatR;

namespace SOSUrbano.Domain.Comands.ComandsInstitution.InstitutionPhoneComands.Update
{
    public class UpdateInstitutionPhoneRequest :
        IRequest<UpdateInstitutionPhoneResponse>
    {
        public Guid Id { get; set; }
        public string Number { get; set; } = string.Empty;
    }
}
