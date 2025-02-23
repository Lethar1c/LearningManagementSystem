namespace LearningManagementSystem.DataAccess.Models
{
    public class Course
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public Guid AuthorId;
        public User Author { get; set; } = null!;
        public List<User> Users { get; set; } = null!;
    }
}
