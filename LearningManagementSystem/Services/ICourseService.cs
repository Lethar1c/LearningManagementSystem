using LearningManagementSystem.Dtos;

namespace LearningManagementSystem.Services
{
    public interface ICourseService
    {
        delegate bool Filter(CourseDto userDto);
        Task<CourseDto> Add(CourseDto courseDto);
        Task<CourseDto?> Get(Guid id);
        Task<List<CourseDto>> GetAll();
        Task<CourseDto?> FirstOrDefault(Filter filter);
        Task Delete(Guid id);
        Task<CourseDto?> Update(Guid id, CourseDto courseDto);
    }
}
