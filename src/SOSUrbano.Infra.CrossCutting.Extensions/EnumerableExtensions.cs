namespace SOSUrbano.Infra.CrossCutting.Extensions
{
    public static class EnumerableExtensions
    {
        /*
         T é o genérico (type), porque pode vir várias classes que 
        utilizarão o método ForEach criado nas linhas abaixo
         */

        /*
         Quando utilizamos o this junto do IEnumerable estamos dizendo
        o seguinte: todos os objetos do tipo IEnumerable vão poder 
        acessar o método que estamos criando chamado ForEach<T>
         */

        /*
         IEnumerable é o um tipo de "lista primária" onde não se pode adicionar valor,
        modificar, acessar índice ou qualquer outra operação. Só se pode percorre-lá
         */

        /*
         Action<T> action é o seguinte: Action<T> é um tipo que representa uma função
        que recebe qualquer tipo, <T>==type, e retorna vazio. A variável action está 
        recebebdo as propriedades do tipo Action<T>
         */

        /*
         Aqui nós estamos criando uma estensão das classes que herdam IEnumerable
        Como IEnumerable é o tipo de lista mais simples, outras clases que a herdam
        poderão utilizar o método ForEach criado abaixo.
         */

        /*
         O Action<T> action abaixo está sendo criado somente o seu escopo, pois não está
        sendo definido o que será feito quando ele obtiver um elemento da lista percorrida.
        Ou seja, é um método genérico que está esperando ser implementado em algum lugar
        do projeto e, no momento em que for, fará algo com esse elemento encontrado.
         */

        /*
         Quando utilizamos o this IEnumerable significa que vamos fazer uma extensão 
        deste método para todas as classes que herdarem o IEnumerable. Como se fosse
        um método nativo do C#.
         */
        public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
        {
            foreach(var element in source)
                action(element);
        }
    }
}
