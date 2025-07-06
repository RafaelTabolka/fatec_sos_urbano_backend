using MediatR;

namespace SOSUrbano.Domain.Commands.CommandsInstitution.InstitutionPhoneCommands.Update
{
    public class UpdateInstitutionPhoneRequest :
        IRequest<UpdateInstitutionPhoneResponse>
    {
        public Guid Id { get; set; }
        public string Number { get; set; } = string.Empty;
    }
}
