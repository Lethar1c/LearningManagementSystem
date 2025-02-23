using LearningManagementSystem.DataAccess.Models;
using LearningManagementSystem.DataAccess.Users;
using LearningManagementSystem.Dtos;

namespace LearningManagementSystem.Services
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepository;
        private IPasswordService _passwordService;

        public UserService(IUserRepository userRepository, IPasswordService passwordService)
        {
            _userRepository = userRepository;
            _passwordService = passwordService;
        }

        private UserDto UserToDto(User user)
        {
            List<CourseDto> courses = [];

            foreach (Course course in user.Courses)
            {
                courses.Add(new CourseDto()
                {
                    Id = course.Id,
                    Name = course.Name,
                    Description = course.Description,
                });
            }

            return new UserDto()
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                Courses = courses
            };
        }

        public async Task<UserDto?> Auth(string email, string password)
        {
            User? user = await _userRepository.FirstOrDefault(u => u.Email == email);
            if (user == null) { return null; }

            if (!_passwordService.Match(password, user.HashedPassword))
            {
                return null;
            }
            return UserToDto(user);
        }

        public async Task Delete(Guid id)
        {
            await _userRepository.Delete(id);
        }

        public async Task<UserDto?> FirstOrDefault(IUserService.Filter filter)
        {
            User? user = await _userRepository.FirstOrDefault(u => filter(UserToDto(u)));
            if (user == null) { return null; }
            return UserToDto(user);
        }

        public async Task<UserDto?> Get(Guid id)
        {
            return await FirstOrDefault(u => u.Id == id);
        }

        public async Task<List<UserDto>> GetAll()
        {
            List<User> users = await _userRepository.GetAll();
            List<UserDto> result = [];
            foreach (var user in users)
            {
                result.Add(UserToDto(user));
            }
            return result;
        }

        public async Task<UserDto?> Register(RegisterUserDto userDto)
        {
            User? user = await _userRepository.FirstOrDefault(u => u.Email == userDto.Email);
            if (user != null) { return null; };
            User newUser = await _userRepository.Add(new User()
            {
                Email = userDto.Email,
                Name = userDto.Name,
                HashedPassword = _passwordService.HashPassword(userDto.Password),
                Courses = []
            });
            return UserToDto(newUser);
        }

        public async Task<UserDto?> Update(Guid id, UpdateUserDto userDto)
        {
            User? user = await _userRepository.Get(id);
            if (user == null) { return null; }
            user.Email = userDto.Email ?? user.Email;
            user.Name = userDto.Name ?? user.Name;
            if (!string.IsNullOrWhiteSpace(userDto.Password))
            {
                user.HashedPassword = _passwordService.HashPassword(userDto.Password);
            }
            await _userRepository.Update(id, user);
            return UserToDto(user);
        }
    }
}
