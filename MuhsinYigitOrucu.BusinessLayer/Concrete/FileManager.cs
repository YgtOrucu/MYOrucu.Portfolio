using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using MuhsinYigitOrucu.BusinessLayer.Abstract;

namespace MuhsinYigitOrucu.BusinessLayer.Concrete
{
    public class FileManager : IFileService
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        public FileManager(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<string> UploadImageAsync(IFormFile file, string folderName)
        {
            if (file == null || file.Length == 0) return null;

            string wwwrootPath = _webHostEnvironment.WebRootPath;
            string folderPath = Path.Combine(wwwrootPath, "images", folderName);

            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);

            string imageName = Guid.NewGuid() + Path.GetExtension(file.FileName);
            string fullPath = Path.Combine(folderPath, imageName);

            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            return $"/images/{folderName}/{imageName}";
        }

        public Task DeleteOldImage(string imageUrl)
        {
            if (!string.IsNullOrEmpty(imageUrl))
            {
                var path = Path.Combine(_webHostEnvironment.WebRootPath, imageUrl.TrimStart('/'));
                if (File.Exists(path)) File.Delete(path);
            }
            return Task.CompletedTask;
        }
    }
}
