using MediatR;

namespace SOSUrbano.Domain.Comands.ComandsUser.UserTypeComands.Update
{
    public class UpdateUserTypeRequest :
        IRequest<UpdateUserTypeResponse>
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
