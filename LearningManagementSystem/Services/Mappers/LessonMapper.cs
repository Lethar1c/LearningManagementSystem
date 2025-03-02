using LearningManagementSystem.DataAccess.Models;
using LearningManagementSystem.Dtos;

namespace LearningManagementSystem.Services.Mappers
{
    public static class LessonMapper
    {
        public static LessonDto LessonToDto(Lesson lesson)
        {
            List<FileDto> files = [];
            foreach (var file in lesson.AttachedFiles)
            {
                files.Add(FileMapper.FileToDto(file));
            }
            return new LessonDto
            {
                Id = lesson.Id,
                Description = lesson.Description,
                Name = lesson.Name,
                Text = lesson.Text,
                AttachedFiles = files
            };
        }
    }
}
