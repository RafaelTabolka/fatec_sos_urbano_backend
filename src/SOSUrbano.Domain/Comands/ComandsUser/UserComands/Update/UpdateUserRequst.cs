using MediatR;

namespace SOSUrbano.Domain.Comands.ComandsUser.UserComands.Update
{
    public class UpdateUserRequst(Guid id) :
        IRequest<UpdateUserResponse>
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Cpf { get; set; } = string.Empty;

        public string UserStatusName { get; set; } = string.Empty;

        public string UserTypeName { get; set; } = string.Empty;
    }
}
