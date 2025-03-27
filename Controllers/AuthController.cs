using IdentityAndDataProtection_Pratik.Dtos;
using IdentityAndDataProtection_Pratik.Jwt;
using IdentityAndDataProtection_Pratik.Models;
using IdentityAndDataProtection_Pratik.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

namespace IdentityAndDataProtection_Pratik.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;

        public AuthController(IUserService service)
        {
            _userService = service;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            var dto = new AddUserDto
            {
                Email = request.Email,
                Password = request.Password
            };
            var result = await _userService.AddUser(dto);
           
            if (result.IsSucceed == true)
                return Ok(result.Message);
            else
            {
                return BadRequest(result.Message);
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var loginUserDto = new LoginUserDto
            {
                Email = request.Email,
                Password = request.Password
            };

            var result = await _userService.LoginUser(loginUserDto);
            var user = result.Data;
            if (!result.IsSucceed)
            {
                return BadRequest(result.Message);
            }

            var config = HttpContext.RequestServices.GetRequiredService<IConfiguration>();

            var token = JwtHelper.GenerateJwt(new JwtDto
            {
                Id = user.Id,
                Email = user.Email,
                UserType = user.UserType,
                SecretKey = config["Jwt:SecretKey"]!,
                Issuer = config["Jwt:Issuer"]!,
                Audience = config["Jwt:Audience"]!,
                ExpireMinute = int.Parse(config["Jwt:ExpireMinutes"]!)
            });
            return Ok(token);
        }
    }
}
