using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UESAN.SHOPPING.CORE.Core.DTOs;
using UESAN.SHOPPING.CORE.Core.Services;

namespace UESAN.SHOPPING.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserServices _userServices;

        public UserController(IUserServices userServices)
        {
            _userServices = userServices;
        }

        [HttpPost("SignIn")]
        public async Task<IActionResult> SignIn([FromBody]LoginDTO loginDTO)
        {
            if (string.IsNullOrEmpty(loginDTO.Email) || string.IsNullOrEmpty(loginDTO.Password))
            {
                return BadRequest("Email and password are required.");
            }

            var user = await _userServices.SignIn(loginDTO.Email, loginDTO.Password);
            if (user == null) return NotFound();
            return Ok(user);
        }

        [HttpPost("SignUp")]
        public async Task<IActionResult> SignUp(UserCreateDTO userCreateDTO)
        {
            if (userCreateDTO == null)
            {
                return BadRequest("User data is required.");
            }
            var userId = await _userServices.SignUp(userCreateDTO);
            return Ok(new { UserId = userId });

        }

    }
}
