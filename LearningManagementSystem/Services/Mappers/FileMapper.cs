using LearningManagementSystem.Dtos;

namespace LearningManagementSystem.Services.Mappers
{
    public static class FileMapper
    {
        public static FileDto FileToDto(DataAccess.Models.File file)
        {
            return new FileDto
            {
                Id = file.Id,
                Name = file.Name,
                Path = file.Path
            };
        }
    }
}
