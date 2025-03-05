using LearningManagementSystem.Config.Results;
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
        Task<AttachFileResult> AttachFile(Guid lessonId, Guid fileId);
        Task<AttachFileResult> DetachFile(Guid lessonId, Guid fileId);
    }
}
