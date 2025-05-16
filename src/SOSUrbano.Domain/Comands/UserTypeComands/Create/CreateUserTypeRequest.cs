using MediatR;

namespace SOSUrbano.Domain.Comands.UserTypeComands.Create
{
    public class CreateUserTypeRequest : IRequest<CreateUserTypeResponse>
    {
        public string Name { get; set; } = string.Empty;
    }
}
