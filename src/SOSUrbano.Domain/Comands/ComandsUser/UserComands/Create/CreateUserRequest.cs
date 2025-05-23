using MediatR;
using SOSUrbano.Domain.Comands.ComandsUser.UserPhoneComands.Create;
using SOSUrbano.Domain.Entities.UserEntity;

namespace SOSUrbano.Domain.Comands.ComandsUser.UserComands.Create
{
    /*
     Este IRequest<CreateUserResponse> é um mediator, um mediador
    da requisição, ou seja, essa linha está fazendo com que as duas
    classes conversem. Estamos dizendo ao mediator, ao mediador da 
    requisição, que, quando o usuário for criado, teremos como
    resposta a classe CreateUserResponse
     */
    public class CreateUserRequest : IRequest<CreateUserResponse>
    {
        public string Name { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Cpf { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public string UserStatusName { get; set; } = string.Empty;

        public string UserTypeName { get; set; } = string.Empty;

        public List<CreateUserPhoneRequest>? UserPhones { get; set; }
    }
}
