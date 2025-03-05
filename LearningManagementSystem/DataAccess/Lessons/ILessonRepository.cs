using LearningManagementSystem.Config.Results;
using LearningManagementSystem.DataAccess.Models;

namespace LearningManagementSystem.DataAccess.Lessons
{
    public interface ILessonRepository
    {
        Task<Lesson?> Get(Guid id);
        Task<List<Lesson>> GetAll();
        Task<Lesson> Add(Lesson lesson);
        Task<Lesson?> Update(Guid id, Lesson lesson);
        Task Delete(Guid id);
        Task<AttachFileResult> AttachFile(Guid lessonId, Guid fileId);
        Task<AttachFileResult> DetachFile(Guid lessonId, Guid fileId);
    }
}
