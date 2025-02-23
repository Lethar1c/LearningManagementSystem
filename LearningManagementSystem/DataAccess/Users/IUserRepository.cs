using LearningManagementSystem.DataAccess.Models;

namespace LearningManagementSystem.DataAccess.Users
{
    public interface IUserRepository
    {
        delegate bool Filter(User user);

        Task<User?> FirstOrDefault(Filter filter);
        Task<User?> Get(Guid id);
        Task<List<User>> GetAll();
        Task<User> Add(User user);
        Task<User?> Update(Guid id, User user);
        Task Delete(Guid id);
    }
}
