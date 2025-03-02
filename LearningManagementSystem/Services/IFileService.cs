using LearningManagementSystem.Dtos;

namespace LearningManagementSystem.Services
{
    public interface IFileService
    {
        bool Upload(IFormFile file);
        void Delete(Guid fileId);
        void Delete(string fileId);
        FileInfoDto? Get(Guid fileId);
        FileInfoDto? Get(string fileId);
    }
}
