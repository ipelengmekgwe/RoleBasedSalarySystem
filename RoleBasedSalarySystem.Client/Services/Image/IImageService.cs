using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace RoleBasedSalarySystem.Client.Services.Image
{
    public interface IImageService
    {
        public Task<(bool, string)> UploadImage(IFormFile file, string fileName = default);
    }
}
