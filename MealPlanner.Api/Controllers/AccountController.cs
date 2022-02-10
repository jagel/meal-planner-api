using Microsoft.AspNetCore.Mvc;

namespace MealPlanner.Api.Controllers
{
    /// <summary>
    /// The main Account controller class.
    /// Responsible for account and administration.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly ILogger<AccountController> _logger;

        public AccountController(ILogger<AccountController> logger)
        {
            _logger = logger;
        }

        [HttpPost("login")]
        public IActionResult Login()
        {
            return Ok();
        }

        [HttpPut("logout")]
        public IActionResult Logout()
        {
            return Ok();
        }


        [HttpPut("GetUser")]
        public IActionResult GetUser()
        {
            return Ok();
        }

        [HttpPost("createAccount")]
        public IActionResult CreateAccount()
        {
            return Ok();
        }


        [HttpPost("changePassword")]
        public IActionResult ChangePassword()
        {
            return Ok();
        }

    }
}
