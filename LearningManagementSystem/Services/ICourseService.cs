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
        Task<bool> Enroll(Guid courseId, Guid userId);
        Task<bool> Leave(Guid courseId, Guid userId);
        Task<bool> AttachLesson(Guid courseId, Guid lessonId);
        Task<bool> DetachLesson(Guid courseId, Guid lessonId);
    }
}
