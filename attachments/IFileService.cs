using Microsoft.AspNetCore.Http;

namespace TechCreare.attachments
{
    public interface IFileService
    {
        Task<string> UploadfileAsync(IFormFile file);
    }
}
