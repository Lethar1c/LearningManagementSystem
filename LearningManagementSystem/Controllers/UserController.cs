using LearningManagementSystem.Dtos;
using LearningManagementSystem.Services;
using Microsoft.AspNetCore.Mvc;

namespace LearningManagementSystem.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _userService.GetAll());
        }

        [HttpGet("{guid}")]
        public async Task<IActionResult> Get(Guid guid)
        {
            UserDto? user = await _userService.Get(guid);
            if (user == null)
            {
                return NotFound($"User with GUID '{guid}' not found in database");
            }
            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterUserDto userDto)
        {
            UserDto? newUser = await _userService.Register(userDto);
            if (newUser == null)
            {
                return BadRequest($"User with email '{userDto.Email}' already exists");
            }
            return Ok(newUser);
        }

        [HttpPut("{guid}")]
        public async Task<IActionResult> Update(Guid guid, UpdateUserDto userDto)
        {
            UserDto? updatedUser = await _userService.Update(guid, userDto);
            if (updatedUser == null)
            {
                return NotFound($"User with GUID '{guid}' not found in database");
            }
            return Ok(updatedUser);
        }

        [HttpDelete("{guid}")]
        public async Task<IActionResult> Delete(Guid guid)
        {
            await _userService.Delete(guid);
            return NoContent();
        }
    }
}
