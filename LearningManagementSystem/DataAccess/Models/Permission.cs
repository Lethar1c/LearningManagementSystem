namespace LearningManagementSystem.DataAccess.Models
{
    public class Permission
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public List<Role> Roles { get; set; } = [];
    }
}
