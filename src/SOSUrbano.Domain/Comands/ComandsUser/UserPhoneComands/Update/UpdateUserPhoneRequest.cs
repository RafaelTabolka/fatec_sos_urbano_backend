using MediatR;

namespace SOSUrbano.Domain.Comands.ComandsUser.UserPhoneComands.Update
{
    public class UpdateUserPhoneRequest :
        IRequest<UpdateUserPhoneResponse>
    {
        public Guid Id { get; set; }
        public string Number { get; set; } = string.Empty;

    }
}
