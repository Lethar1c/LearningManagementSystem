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
    }
}
