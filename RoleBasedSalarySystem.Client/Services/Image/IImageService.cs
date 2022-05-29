using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace RoleBasedSalarySystem.Client.Services.Image
{
    public interface IImageService
    {
        public Task<string> UploadImage(IFormFile file, string fileName = default);
        public Task<IFormFile> RetriveImage(string searchString);
    }
}
