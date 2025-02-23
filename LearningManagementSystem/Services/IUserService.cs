using LearningManagementSystem.Dtos;

namespace LearningManagementSystem.Services
{
    public interface IUserService
    {
        delegate bool Filter(UserDto userDto);
        Task<UserDto?> Register(RegisterUserDto userDto);
        Task<UserDto?> Auth(string email, string password);
        Task<UserDto?> Get(Guid id);
        Task<List<UserDto>> GetAll();
        Task<UserDto?> FirstOrDefault(Filter filter);
        Task Delete(Guid id);
        Task<UserDto?> Update(Guid id, UserDto userDto);
    }
}
