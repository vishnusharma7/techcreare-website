using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace TechCreare.attachments
{
    public class LocalFileUploadService : IFileService
    {
        private readonly IHostingEnvironment environment;
        public LocalFileUploadService(IHostingEnvironment environment) {
            this.environment = environment;
        }
        public async Task<string> UploadfileAsync(IFormFile file)
        {
            var Myfile = Path.Combine(environment.ContentRootPath, @"www.root\media", file.FileName);
            using var fileStream = new FileStream(Myfile, FileMode.Create);
            await file.CopyToAsync(fileStream);
            return Myfile;
        }
    }
}
