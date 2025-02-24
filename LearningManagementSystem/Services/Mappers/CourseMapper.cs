using LearningManagementSystem.DataAccess.Models;
using LearningManagementSystem.Dtos;

namespace LearningManagementSystem.Services.Mappers
{
    public static class CourseMapper
    {
        // TODO: Создать EnrolledCourses, настроить связь HasMany.WithMany
        public static CourseDto CourseToDto(Course course)
        {
            UserDto? authorDto;
            if (course.Author == null)
            {
                authorDto = null;
            }
            else
            {
                authorDto = UserMapper.UserToDto(course.Author);
            }
            return new CourseDto()
            {
                Id = course.Id,
                Name = course.Name,
                Description = course.Description,
                Author = authorDto
            };
        }
    }
}
