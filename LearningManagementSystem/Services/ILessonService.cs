using LearningManagementSystem.Dtos;

namespace LearningManagementSystem.Services
{
    public interface ILessonService
    {
        Task<LessonDto> Add(LessonDto lessonDto);
        Task<LessonDto?> Get(Guid id);
        Task<List<LessonDto>> GetAll();
        Task Delete(Guid id);
        Task<LessonDto?> Update(Guid id, LessonDto lessonDto);
        Task<bool> AttachFile(Guid lessonId, Guid fileId);
        Task<bool> DetachFile(Guid lessonId, Guid fileId);
    }
}
