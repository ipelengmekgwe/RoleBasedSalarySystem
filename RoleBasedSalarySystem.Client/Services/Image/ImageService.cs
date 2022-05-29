using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Linq;
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

        public async Task<IFormFile> RetriveImage(string searchString)
        {
            try
            {
                var imageDirectory = Path.Combine(_hostEnvironment.WebRootPath.Replace(".Client", ".API"), "images");
                var image = new DirectoryInfo(imageDirectory).GetFiles()
                    .FirstOrDefault(x => x.Name.Contains(searchString) || x.Name == "no-image.png");

                await using var stream = File.OpenRead(image.FullName);

                return new FormFile(stream, 0, stream.Length, "ImageFile", image.Name)
                {
                    Headers = new HeaderDictionary(),
                    ContentDisposition = $"form-data; name=\"ImageFile\"; filename=\"{image.Name}\"",
                    ContentType = $"image/{image.Extension.Replace(".", "")}",
                };
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<string> UploadImage(IFormFile file, string fileName = default)
        {
            try
            {
                var imageDirectory = Path.Combine(_hostEnvironment.WebRootPath.Replace(".Client", ".API"), "images");

                if (file != null)
                {
                    var fileInfo = new FileInfo(file.FileName);
                    fileName = (fileName ?? Guid.NewGuid().ToString()) + fileInfo.Extension;
                    var path = Path.Combine(imageDirectory, fileName);

                    var memoryStream = new MemoryStream();
                    await file.OpenReadStream().CopyToAsync(memoryStream);

                    if (!Directory.Exists(imageDirectory))
                        Directory.CreateDirectory(imageDirectory);

                    await using var stream = new FileStream(path, FileMode.Create, FileAccess.Write);
                    memoryStream.WriteTo(stream);

                    return $"images/{fileName}";
                }
                else if (fileName != default)
                {
                    var image = new DirectoryInfo(imageDirectory).GetFiles($"{fileName}*").FirstOrDefault();

                    if (image != null)
                        return $"images/{image.Name}";
                }

                return "images/no-image.png";
            }
            catch (Exception)
            {
                return "images/no-image.png";
            }
        }
    }
}
