namespace SOSUrbano.Domain.Commands.CommandsUser.UserCommands.Create
{
    public class CreateUserResponse(Guid id, string accessToken)
    {
        /*
         Este é um construtor primário, recurso disponível no .NET8
        em diante. Ao invés de criar comumente o construtor abaixo
        dos métodos, nós podemos criar o construtor diretamente
        na classe e passar seus valores para os métodos abaixo
         */
        public Guid Id { get; } = id;

        public string AccessToken { get; } = accessToken;
    }
}
