namespace LearningManagementSystem.Dtos
{
    public class CourseDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public UserDto Author { get; set; } = null!;
        public List<LessonDto> Lessons { get; set; } = [];
        public CourseDto() { }
    }
}
