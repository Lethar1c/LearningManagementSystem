using LearningManagementSystem.DataAccess.Models;
using LearningManagementSystem.Dtos;

namespace LearningManagementSystem.Services
{
    public interface IAdminService
    {
        public Task<Role> CreateRole(RoleDto role);
        public Task UpdateRolePermittions(Guid roleId, List<Guid> permissionIds);
        public Task UpdateUserRole(Guid roleId, Guid userId);
    }
}
