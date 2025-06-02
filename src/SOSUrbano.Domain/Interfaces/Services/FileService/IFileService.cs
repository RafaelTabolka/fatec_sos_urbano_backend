using Microsoft.AspNetCore.Http;

namespace SOSUrbano.Domain.Interfaces.Services.FileService
{
    public interface IFileService
    {
        Task<List<string>> SavePhotosAsync(List<IFormFile> files);
    }
}
