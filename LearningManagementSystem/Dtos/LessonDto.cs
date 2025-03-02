namespace LearningManagementSystem.Dtos
{
    public class LessonDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = "Lesson";
        public string Description { get; set; } = "Lesson Description";
        public string Text { get; set; } = "Lesson Text";
        public List<FileDto> AttachedFiles { get; set; } = [];
    }
}
