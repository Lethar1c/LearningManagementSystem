using LearningManagementSystem.Config;
using LearningManagementSystem.Dtos;
using LearningManagementSystem.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace LearningManagementSystem.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        IUserService _userService;
        public AuthController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost]
        public async Task<IActionResult> Auth(AuthDto authDto)
        {
            UserDto? userDto = await _userService.Auth(authDto.Email, authDto.Password);
            if (userDto == null)
            {
                return Unauthorized();
            }
            List<Claim> claims = [
                    new Claim(ClaimTypes.NameIdentifier, userDto.Id.ToString()),
                    new Claim(ClaimTypes.Email, userDto.Email),
                    new Claim(ClaimTypes.Name, userDto.Name)
                ];
            var jwt = new JwtSecurityToken(
                    issuer: AuthConfig.ValidIssuer,
                    audience: AuthConfig.ValidAudience,
                    claims: claims,
                    expires: DateTime.UtcNow.AddMonths(3),
                    signingCredentials:
                    new SigningCredentials(AuthConfig.GetSymmetricSecurityKey(),
                                           SecurityAlgorithms.HmacSha256)
                );
            return Ok(new JwtSecurityTokenHandler().WriteToken(jwt));
        }
    }
}
