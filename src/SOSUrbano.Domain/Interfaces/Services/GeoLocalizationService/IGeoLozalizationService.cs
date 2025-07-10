using System.Text.Json;

namespace SOSUrbano.Domain.Interfaces.Services.GeoLocalizationService
{
    public interface IGeoLozalizationService
    {
        Task<JsonElement> GetAddressFromCoordinatesAsync(double latitude, double longitude);
    }
}
