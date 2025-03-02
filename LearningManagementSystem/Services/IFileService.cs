using LearningManagementSystem.Dtos;

namespace LearningManagementSystem.Services
{
    public interface IFileService
    {
        bool Upload(IFormFile file);
        void Delete(Guid fileId);
        void Delete(string fileId);
        FileDto? Get(Guid fileId);
        FileDto? Get(string fileId);
    }
}
