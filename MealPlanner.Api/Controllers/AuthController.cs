using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using JGL.Security.Auth.Data.Requests;
using JGL.Security.Auth.Domain.Interfaces;

namespace JGL.Api.Controllers
{
    /// <summary>
    /// Authentication controller
    /// Responisble for validate access to system and logout
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(
        ILogger<AuthController> logger,
        IAuthService authService
        ) : AuthBaseController
    {
        
        /// <summary>
        /// Login user, creates user session
        /// </summary>
        /// <param name="userRequest">User request model</param>
        /// <returns>Json Web Token</returns>
        [HttpPost("login", Name = "[controller].Login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] UserLoginRequest userRequest)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var authResponse = await authService.LoginAsync(userRequest);

            var authenticated = await GenerateValidCredentialsAsync(authResponse);

            if (!authenticated)
            {
                return Unauthorized();
            }
            return Ok();
        }

        /// <summary>
        /// Logout user, clear credentials
        /// </summary>
        /// <returns>Redirect to page</returns>
        [HttpGet("logout", Name = "[controller].logout")]
        public async Task<IActionResult> Logout()
        {
            await authService.LogoutAsync();

            Response.Cookies.Delete(ConfigVar.TokenCookie);
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect("/");
        }

    }
}
