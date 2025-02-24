using LearningManagementSystem.DataAccess.Courses;
using LearningManagementSystem.DataAccess.Models;
using LearningManagementSystem.Dtos;
using LearningManagementSystem.Services.Mappers;

namespace LearningManagementSystem.Services
{
    public class CourseService : ICourseService
    {
        ICourseRepository _courseRepository;
        public CourseService(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }
        public async Task<CourseDto> Add(CreateCourseDto courseDto)
        {
            Course course = await _courseRepository.Add(new Course()
            {
                Name = courseDto.Name,
                Description = courseDto.Description,
                AuthorId = courseDto.AuthorId,
            });
            return CourseMapper.CourseToDto(course);
        }

        public async Task Delete(Guid id)
        {
            await _courseRepository.Delete(id);
        }

        public async Task<CourseDto?> FirstOrDefault(ICourseService.Filter filter)
        {
            Course? course = await _courseRepository.FirstOrDefault(c => filter(CourseMapper.CourseToDto(c)));
            if (course == null) return null;
            return CourseMapper.CourseToDto(course);
        }

        public async Task<CourseDto?> Get(Guid id)
        {
            Course? course = await _courseRepository.Get(id);
            return course == null ? null : CourseMapper.CourseToDto(course);
        }

        public async Task<List<CourseDto>> GetAll()
        {
            return (await _courseRepository.GetAll())
                .Select(c => CourseMapper.CourseToDto(c))
                .ToList();
        }

        public async Task<CourseDto?> Update(Guid id, UpdateCourseDto courseDto)
        {
            Course? newCourse = await _courseRepository.Update(id, new Course()
            {
                Name = courseDto.Name,
                Description = courseDto.Description,
                AuthorId = courseDto.AuthorId,
            });
            if (newCourse == null) return null;
            return CourseMapper.CourseToDto(newCourse);
        }
    }
}
