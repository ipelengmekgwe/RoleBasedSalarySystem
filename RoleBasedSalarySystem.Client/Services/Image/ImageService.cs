using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading.Tasks;

namespace RoleBasedSalarySystem.Client.Services.Image
{
    public class ImageService : IImageService
    {
        private readonly IWebHostEnvironment _hostEnvironment;

        public ImageService(IWebHostEnvironment hostEnvironment)
        {
            _hostEnvironment = hostEnvironment;
        }

        public async Task<(bool, string)> UploadImage(IFormFile file, string fileName = default)
        {
            try
            {
                if (file != null)
                {
                    var fileInfo = new FileInfo(file.FileName);
                    fileName = (fileName ?? Guid.NewGuid().ToString()) + fileInfo.Extension;
                    var imageDirectory = Path.Combine(_hostEnvironment.WebRootPath.Replace(".Client", ".API"), "images");
                    var path = Path.Combine(imageDirectory, fileName);

                    var memoryStream = new MemoryStream();
                    await file.OpenReadStream().CopyToAsync(memoryStream);

                    if (!Directory.Exists(imageDirectory))
                        Directory.CreateDirectory(imageDirectory);

                    await using var stream = new FileStream(path, FileMode.Create, FileAccess.Write);
                    memoryStream.WriteTo(stream);

                    return (true, $"images/{fileName}");
                }

                return (false, fileName);
            }
            catch (Exception)
            {
                return (false, fileName);
            }
        }
    }
}
