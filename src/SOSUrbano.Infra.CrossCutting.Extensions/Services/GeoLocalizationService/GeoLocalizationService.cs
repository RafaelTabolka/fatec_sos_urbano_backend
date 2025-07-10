using System.Text.Json;
using Microsoft.Extensions.Configuration;
using SOSUrbano.Domain.Interfaces.Services.GeoLocalizationService;

namespace SOSUrbano.Infra.CrossCutting.Extensions.Services.GeoLocalizationService
{
    public class GeoLocalizationService(
        HttpClient httpClient,
        IConfiguration configuration) : IGeoLozalizationService
    {
        // Essa api vem do site LocationIQ. Gratuita e 5k de requisições grátis por dia

        public async Task<JsonElement> GetAddressFromCoordinatesAsync(double latitude, double longitude)
        {
            if (latitude < -90 || latitude > 90 || longitude < -180 || longitude > 180)
                throw new Exception("Valores de latitude e longitude incorretos.");

            string accessToken = configuration["LocationIQ:Token"]!;

            // Essa é a url para acessar a API
            var url = $"https://us1.locationiq.com/v1/reverse?" +
                $"key={accessToken}&" +
                $"lat={latitude.ToString().Replace(",", ".")}&" +
                $"lon={longitude.ToString().Replace(",", ".")}&" +
                $"format=json";
            
            // Essa é a chamada get para a url da API e a resposta são todas as informações do get
            // contendo headers, status da requisição e json
            var response = await httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new Exception($"Erro ao buscar com a API. Status {response.StatusCode}. Conteúdo: {errorContent}");
            }
                

            // Aqui é extraído o Json da responsta, mas ele vem num formato de string como no exemplo 
            // a seguir: "{ \"display_name\": \"Rua Tal, Cidade Tal, Brasil\" }"
            var json = await response.Content.ReadAsStringAsync();

            // Aqui nós pegamos o Json em formato de string e transformamos em um Json navegável com 
            // a estrutura que conhecemos para podermos acessar os campos do Json retornado
            var root = JsonDocument.Parse(json).RootElement;

            return root;
        }
    }
}
