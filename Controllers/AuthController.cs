using IdentityAndDataProtection_Pratik.Dtos;
using IdentityAndDataProtection_Pratik.Models;
using IdentityAndDataProtection_Pratik.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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

        [HttpPost]
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
            if (!result.IsSucceed)
            {
                return BadRequest(result.Message);
            }
            return Ok();
        }
    }
}
