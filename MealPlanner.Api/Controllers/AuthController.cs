using JGL.Globals.Api.Controllers;
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
    public class AuthController : BaseController
    {
        private readonly ILogger<AuthController> _logger;
        private readonly IAuthService _authService;

        public AuthController(ILogger<AuthController> logger,
            IAuthService authService)
        {
            _logger = logger;
            _authService = authService;
        }

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

            
            var authResponse = await _authService.LoginAsync(userRequest);

            if (!authResponse.Authenticated)
            {
                return Ok(authResponse.ErrorResponse);
            }
            _logger.LogWarning("User {0} logged in by user/password", userRequest.Email);
            Response.Cookies.Delete(ConfigVar.TokenCookie);
            Response.Cookies.Append(ConfigVar.TokenCookie, authResponse.Jwt, new CookieOptions{HttpOnly = true,});

            var properties = new AuthenticationProperties { IsPersistent = userRequest.RememberAccount??false };

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                authResponse.ClaimsPrincipal,
                properties);

            return Ok("success");
        }

        [HttpGet("logout", Name = "[controller].logout")]
        public async Task<IActionResult> Logout()
        {
            await _authService.LogoutAsync();

            Response.Cookies.Delete(ConfigVar.TokenCookie);
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect("/");
        }

        /*
private readonly IUserSessionService _userSessionService;
private readonly ILogger<AuthController> _logger;
private readonly IConfiguration _configuration;

public AuthController(IUserSessionService userSessionService,
                     ILogger<AuthController> logger,
                     IConfiguration configuration)
{
   _userSessionService = userSessionService;
   _logger = logger;
   _configuration = configuration;
}

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

   if (!await _userSessionService.AreCredentialValidAsync(userRequest))
       return Unauthorized();


   //var claims = await _userClaimPrincipalFactory.CreateAsync(new ApplicationUser { });
   await _userSessionService.LogInAsync(new() { });

   var claimsList = new List<Claim>
   {
       new Claim(ClaimTypes.Email , userRequest.Email),
       new Claim(ClaimTypes.NameIdentifier , "1")
   };

   var identity = new ClaimsIdentity(claimsList, CookieAuthenticationDefaults.AuthenticationScheme);
   var principal = new ClaimsPrincipal(identity);
   var properties = new AuthenticationProperties { IsPersistent = true };
   await HttpContext.SignInAsync(
       CookieAuthenticationDefaults.AuthenticationScheme,
       principal,
       properties);

   return SignIn(principal,properties,CookieAuthenticationDefaults.AuthenticationScheme);
}

[HttpGet("googleLoginCallback", Name = "[controller].GoogleLoginCallback")]
[AllowAnonymous]
public async Task<IActionResult> GoogleLoginCallback()
{
   var result = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);
   var properties = result.Properties.Items;
   var externalClaims = result.Principal.Claims.ToList();
   var subjectId = externalClaims.Where(x => x.Type == ClaimTypes.NameIdentifier).Select(x => x.Value).FirstOrDefault();

   var identity = new ClaimsIdentity(externalClaims, CookieAuthenticationDefaults.AuthenticationScheme);
   var principal = new ClaimsPrincipal(identity);


   //deleted temporary cookie used during google authentication
   await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
   await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

   var url = "";
   if (properties.ContainsKey(Domain.Definitions.ReturnUrl))
       url = properties[Domain.Definitions.ReturnUrl];

   return Redirect(url);
}


/// <summary>
/// Ends session for user, returns if was able to log out succesfully
/// </summary>
/// <returns>True</returns>
[HttpGet("logout", Name = "[controller].Logout")]
public async Task<IActionResult> Logout()
{
   await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
   return Redirect("/");
}



*/

    }
}
