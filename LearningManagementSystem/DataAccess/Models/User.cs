namespace LearningManagementSystem.DataAccess.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string HashedPassword { get; set; } = null!;
        public List<Course> Courses { get; set; } = null!;
        public User() { }
    }
}
