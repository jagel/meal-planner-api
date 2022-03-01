using MealPlanner.Data.Auth;
using MealPlanner.Domain.Auth.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MealPlanner.Api.Controllers
{
    /// <summary>
    /// Authentication controller
    /// Responisble for validate access to system and logout
    /// </summary>
    [ApiController]
    public class AuthController : BaseController
    {
        private readonly IUserSessionService _userSessionService;
        private readonly ILogger<AuthController> _logger;

        public AuthController(IUserSessionService userSessionService, 
                              ILogger<AuthController> logger)
        {
            _userSessionService = userSessionService;
            _logger = logger;
        }

        /// <summary>
        /// Login user, creates user session
        /// </summary>
        /// <param name="userRequest">User request model</param>
        /// <returns>Json Web Token</returns>
        [HttpPost("login", Name = "[controller].Login")]
        public async Task<IActionResult> Login([FromBody] UserLoginRequest userRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!await _userSessionService.AreCredentialValidAsync(userRequest))
            {
                return BadRequest("Invalid Session");
            }

            var jwt = await _userSessionService.LogInAsync(userRequest);

            return Ok(jwt);
        }

        /// <summary>
        /// Ends session for user, returns if was able to log out succesfully
        /// </summary>
        /// <param name="UserRequest">Model user</param>
        /// <returns>True</returns>
        [HttpPost("logout", Name = "[controller].Logout")]
        public async Task<IActionResult> Logout([FromBody] UserLoginRequest UserRequest)
        {
            var loggedOut = await _userSessionService.LogOutAsync();

            return Ok(loggedOut);
        }

      
    }
}
