using LearningManagementSystem.DataAccess;
using LearningManagementSystem.DataAccess.Models;
using LearningManagementSystem.DataAccess.Users;
using LearningManagementSystem.Dtos;
using Microsoft.EntityFrameworkCore;

namespace LearningManagementSystem.Services
{

    public class AdminService : IAdminService
    {
        ApplicationContext _context;
        IUserRepository _userRepository;
        public AdminService(ApplicationContext context, IUserRepository userRepository)
        {
            _context = context;
            _userRepository = userRepository;
        }
        public async Task<Role> CreateRole(RoleDto role)
        {
            List<Permission> permissions = [];
            foreach (PermittionDto permissionDto in role.Permittions)
            {
                Permission? permission = await _context.Permissions.FirstOrDefaultAsync(p => p.Id == permissionDto.Id);
                if (permission == null)
                {
                    permission = new Permission() { Name = permissionDto.Name };
                    await _context.Permissions.AddAsync(permission);
                }
                permissions.Add(permission);
            }
            Role newRole = new Role
            {
                Name = role.Name,
                Permissions = permissions
            };
            await _context.Roles.AddAsync(newRole);
            await _context.SaveChangesAsync();
            return newRole;
        }

        public async Task UpdateRolePermittions(Guid roleId, List<Guid> permissionIds)
        {
            Role? role = await _context.Roles.FirstOrDefaultAsync(r => r.Id == roleId);
            List<Permission> permissions = [];
            if (role == null) { throw new Exception("Role not found"); }
            foreach (Guid permissionId in permissionIds)
            {
                Permission? permission = await _context.Permissions.FirstOrDefaultAsync(p => permissionId == roleId);
                if (permission != null) { permissions.Add(permission); }
            }
            role.Permissions = permissions;
            await _context.SaveChangesAsync();
        }

        public async Task UpdateUserRole(Guid roleId, Guid userId)
        {
            User? user = await _userRepository.Get(userId);
            Role? role = await _context.Roles.FirstOrDefaultAsync(role => role.Id == roleId);
            if (role == null)
            {
                throw new Exception("Role not found");
            }
            if (user == null)
            {
                throw new Exception("User not found");
            }
            user.Role = role;
            await _context.SaveChangesAsync();
        }
    }
}
