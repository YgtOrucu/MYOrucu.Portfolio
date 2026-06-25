using Microsoft.AspNetCore.Http;

namespace MuhsinYigitOrucu.BusinessLayer.Abstract
{
    public interface IFileService
    {
        Task<string> UploadImageAsync(IFormFile file, string folderName);
        Task DeleteOldImage(string imageUrl);
    }
}
