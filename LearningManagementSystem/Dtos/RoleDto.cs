namespace LearningManagementSystem.Dtos
{
    public class RoleDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = "";
        public List<PermittionDto> Permittions { get; set; } = [];
    }
}
