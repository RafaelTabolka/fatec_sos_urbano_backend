using Microsoft.AspNetCore.Http;

namespace SOSUrbano.Domain.Interfaces.Services.FileService
{
    public interface IFileService
    {
        Task<List<string>> CreatePathPhotosAsync(List<IFormFile> files);

        Task<string> UpdatePathPhotoAsync(IFormFile file);
    }
}
