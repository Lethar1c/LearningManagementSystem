using LearningManagementSystem.Config.Results;
using LearningManagementSystem.Dtos;

namespace LearningManagementSystem.Services
{
    public interface ICourseService
    {
        delegate bool Filter(CourseDto userDto);
        Task<CourseDto> Add(CreateCourseDto courseDto);
        Task<CourseDto?> Get(Guid id);
        Task<List<CourseDto>> GetAll();
        Task<CourseDto?> FirstOrDefault(Filter filter);
        Task Delete(Guid id);
        Task<CourseDto?> Update(Guid id, UpdateCourseDto courseDto);
        Task<EnrollUserResult> Enroll(Guid courseId, Guid userId);
        Task<EnrollUserResult> Leave(Guid courseId, Guid userId);
        Task<AttachLessonResult> AttachLesson(Guid courseId, Guid lessonId);
        Task<AttachLessonResult> DetachLesson(Guid courseId, Guid lessonId);
    }
}
