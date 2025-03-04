namespace LearningManagementSystem.DataAccess.Models
{
    public class Lesson
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = "Lesson";
        public string Description { get; set; } = "Lesson Description";
        public string Text { get; set; } = "Lesson Text";
        public List<File> AttachedFiles { get; set; } = [];
        public Course? Course { get; set; }
        public Guid? CourseId { get; set; }
    }
}
