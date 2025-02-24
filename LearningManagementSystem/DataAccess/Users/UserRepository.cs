using LearningManagementSystem.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace LearningManagementSystem.DataAccess.Users
{
    public class UserRepository : IUserRepository
    {
        ApplicationContext _context;
        public UserRepository(ApplicationContext context)
        {
            _context = context;
        }
        public async Task<User> Add(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task Delete(Guid id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<User?> FirstOrDefault(IUserRepository.Filter filter)
        {
            List<User> users = await _context.Users
                .Include(u => u.Courses)
                .Include(u => u.EnrolledCourses)
                .ToListAsync();
            foreach (User user in users)
            {
                if (filter(user)) return user;
            }
            return null;
        }

        public async Task<User?> Get(Guid id)
        {
            return await _context.Users
                .Include(u => u.Courses)
                .Include(u => u.EnrolledCourses)
                .FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<List<User>> GetAll()
        {
            return await _context.Users
                .Include(u => u.Courses)
                .Include(u => u.EnrolledCourses)
                .ToListAsync();
        }

        public async Task<User?> Update(Guid id, User user)
        {
            var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
            if (existingUser == null) return null;

            existingUser.Name = user.Name;
            existingUser.Email = user.Email;
            existingUser.HashedPassword = user.HashedPassword;

            await _context.SaveChangesAsync();
            return existingUser;
        }
    }
}
