namespace LearningManagementSystem.DataAccess.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string HashedPassword { get; set; } = null!;
        public Role Role { get; set; } = new() { Name = "User", Permissions = [] };
        public List<Course> Courses { get; set; } = [];
        public List<Course> EnrolledCourses { get; set; } = [];
        public User() { }
    }
}
