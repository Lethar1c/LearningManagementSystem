namespace LearningManagementSystem.Dtos
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public List<CourseDto> Courses { get; set; } = null!;
        public UserDto() { }
    }
}
