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
        public async Task<User?> Add(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task Delete(Guid id)
        {
            await _context.Users.Where(u => u.Id == id).ExecuteDeleteAsync();
        }

        public async Task<User?> FirstOrDefault(IUserRepository.Filter filter)
        {
            return await _context.Users.FirstOrDefaultAsync(u => filter(u));
        }

        public async Task<User?> Get(Guid id)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<List<User>> GetAll()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User?> Update(Guid id, User user)
        {
            await _context.Users.Where(u => u.Id == id).ExecuteUpdateAsync(setters =>
                setters.SetProperty(u => u.Name, user.Name)
                       .SetProperty(u => u.Email, user.Email)
                       .SetProperty(u => u.HashedPassword, user.HashedPassword)
            );
            return user;
        }
    }
}
