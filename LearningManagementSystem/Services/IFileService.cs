using Microsoft.Extensions.FileProviders;

namespace LearningManagementSystem.Services
{
    public interface IFileService
    {
        bool Upload(IFormFile file);
        void Delete(Guid fileId);
        void Delete(string fileId);
        IFileInfo? Get(Guid fileId);
        IFileInfo? Get(string fileId);
    }
}
