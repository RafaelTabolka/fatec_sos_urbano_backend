using SOSUrbano.Domain.Commands.CommandsUser.UserCommands.Dto;
using SOSUrbano.Domain.Entities.UserEntity;

namespace SOSUrbano.Domain.Commands.CommandsUser.UserCommands.List
{
    /*
     Aqui nós temos o construtor pedindo um IEnumerable e a propriedade
    Users está recebendo um users.ToList() que transforma IEnumerable
    em uma List<User> que por sua vez implementa o IReadOnlyCollection,
    fazemdo com que a chamada de função no handler funcione.
     */
    public class ListUserResponse(IEnumerable<DtoUserResponse> users)
    {
        public IReadOnlyCollection<DtoUserResponse> Users { get; } = users.ToList();
    }
}
