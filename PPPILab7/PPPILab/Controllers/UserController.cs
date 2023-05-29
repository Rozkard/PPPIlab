
using Microsoft.AspNetCore.Mvc;
using PPPILab.Models;
using PPPILab.Services;
using Microsoft.Extensions.Configuration;
namespace PPPILab.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IJwtService? _jwtService;

        public UserController(IUserService userService, IJwtService? jwtService = null)
        {
            _userService = userService;
            _jwtService = jwtService;
        }

        [HttpPost("authorize")]
        public IActionResult Authorize([FromBody] LoginModel loginModel)
        {
            UserModel user = _userService.AuthorizeUser(loginModel.Email, loginModel.Password);
            if (user == null)
            {
                return Unauthorized();
            }

          
            string token = GenerateJwtToken(user);

            return Ok(new { Token = token });
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] UserModel userModel)
        {
        
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            UserModel registeredUser = _userService.RegisterUser(userModel);

         
            string token = GenerateJwtToken(registeredUser);

            return Ok(new { Token = token, User = registeredUser });
        }

        private string GenerateJwtToken(UserModel user)
        {
            return _jwtService.GenerateJwtToken(user);
        }
    }
}
