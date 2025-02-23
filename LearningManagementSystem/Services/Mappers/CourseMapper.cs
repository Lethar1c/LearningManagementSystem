using LearningManagementSystem.DataAccess.Models;
using LearningManagementSystem.Dtos;

namespace LearningManagementSystem.Services.Mappers
{
    public class CourseMapper
    {
        public CourseDto CourseToDto(Course course)
        {
            return new CourseDto()
            {
                Id = course.Id,
                Name = course.Name,
                Description = course.Description,
                Author = UserMapper.UserToDto(course.Author)
            };
        }
    }
}
