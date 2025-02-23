
using Microsoft.EntityFrameworkCore;

namespace LearningManagementSystem.DataAccess.Users
{
    public class UserRepository : IUserRepository
    {
        public async Task<User?> Add(User user)
        {
            using (ApplicationContext context = new())
            {
                await context.Users.AddAsync(user);
                await context.SaveChangesAsync();
            }
            return user;
        }

        public async Task Delete(Guid id)
        {
            using (ApplicationContext context = new())
            {
                await context.Users.Where(u => u.Id == id).ExecuteDeleteAsync();
            }
        }

        public async Task<User?> FirstOrDefault(IUserRepository.Filter filter)
        {
            using (ApplicationContext context = new())
            {
                return await context.Users.FirstOrDefaultAsync(u => filter(u));
            }
        }

        public async Task<User?> Get(Guid id)
        {
            using (ApplicationContext context = new())
            {
                return await context.Users.FirstOrDefaultAsync(u => u.Id == id);
            }
        }

        public async Task<List<User>> GetAll()
        {
            using (ApplicationContext context = new())
            {
                return await context.Users.ToListAsync();
            }
        }

        public async Task<User?> Update(Guid id, User user)
        {
            using (ApplicationContext context = new())
            {
                await context.Users.Where(u => u.Id == id).ExecuteUpdateAsync(setters =>
                    setters.SetProperty(u => u.Name, user.Name)
                           .SetProperty(u => u.Email, user.Email)
                           .SetProperty(u => u.HashedPassword, user.HashedPassword)
                );
            }
            return user;
        }
    }
}
