using LearningManagementSystem.DataAccess.Models;
using LearningManagementSystem.Dtos;

namespace LearningManagementSystem.Services.Mappers
{
    public class RoleMapper
    {
        public static RoleDto RoleToDto(Role role)
        {
            List<PermittionDto> permittionDtos = [];
            foreach (Permission permission in role.Permissions)
            {
                permittionDtos.Add(new PermittionDto
                {
                    Id = permission.Id,
                    Name = permission.Name,
                });
            }
            return new RoleDto
            {
                Id = role.Id,
                Name = role.Name,
                Permittions = permittionDtos
            };
        }
    }
}
