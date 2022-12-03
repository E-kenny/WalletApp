using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WalletApp.Abstractions.Services;
using WalletApp.Models.DTO;

namespace WalletApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ILogger<UserController> _logger;

        public UserController(IUserService userService, ILogger<UserController> logger)
        {
            _logger = logger;
            _logger.LogDebug(1, "NLog injected into HomeController");
            _userService = userService;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(UserDTO user)
        {

            var register = await _userService.Register(user);

            if (user == null)
                return NotFound();

            return Ok(register);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            _logger.LogInformation("Hello, this is the index!");
            var token = await _userService.LoginAsync(model);
            if (token != null) return Ok(token);           
            return Problem();   
        }



    }
}
