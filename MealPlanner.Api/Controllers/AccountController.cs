using MealPlanner.Data.Auth;
using MealPlanner.Data.Globals;
using MealPlanner.Domain.Auth.Interfaces;
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
        private readonly IUserService _userService;

        public AccountController(ILogger<AccountController> logger, IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        [HttpPut("GetUser")]
        public IActionResult GetUser()
        {
            return Ok();
        }

        [HttpPost("createAccount", Name = "[controller].CreateAccount")]
        [ProducesResponseType(typeof(ModelResponse<UserResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateAccount(CreateUserRequest createUserRequest)
        {
            var userSaved = await _userService.CreateUserAsync(createUserRequest);

            var respone = new ModelResponse<UserResponse>
            {
                Data = userSaved
            };

            return Ok(userSaved);
        }


        [HttpPost("changePassword")]
        public IActionResult ChangePassword()
        {
            return Ok();
        }

    }
}
