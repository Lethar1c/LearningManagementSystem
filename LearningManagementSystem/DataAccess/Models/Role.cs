namespace LearningManagementSystem.DataAccess.Models
{
    public class Role
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public List<Permission> Permissions { get; set; } = [];
    }
}
