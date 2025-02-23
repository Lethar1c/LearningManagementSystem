using LearningManagementSystem.Dtos;

namespace LearningManagementSystem.Services
{
    public class CourseService : ICourseService
    {
        public Task<CourseDto> Add(CourseDto courseDto)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<CourseDto?> FirstOrDefault(ICourseService.Filter filter)
        {
            throw new NotImplementedException();
        }

        public Task<CourseDto?> Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<CourseDto>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<CourseDto?> Update(Guid id, CourseDto userDto)
        {
            throw new NotImplementedException();
        }
    }
}
