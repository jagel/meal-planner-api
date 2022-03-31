using JGL.Globals.Api.Controllers;
using MealPlanner.Data.Auth;
using MealPlanner.Domain.Auth.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace MealPlanner.Api.Controllers
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
        private readonly IUserSessionService _userSessionService;
        private readonly IUserService _userService;
        private readonly IJwtService _jwtService;

        public AuthController(IJwtService jwtService,
            ILogger<AuthController> logger,
            IUserSessionService userSessionService, 
            IUserService userService)
        {
            _jwtService = jwtService;
            _logger = logger;
            _userSessionService = userSessionService;
            _userService = userService;
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

            var userId = await _userService.GetUserIdByEmailAsync(userRequest.Email);
            var jwt = _jwtService.GenerateToken(userId);

            Response.Cookies.Append(ConfigVar.TokenCookie, jwt, new CookieOptions
            {
                HttpOnly = true
            });

            var properties = new AuthenticationProperties { IsPersistent = true };
            var claimPrincipal = await _userSessionService.GetClaimsPrincipalByUserId(userId);

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                claimPrincipal,
                properties);

            return Ok("success");
        }

        [HttpGet("getUser", Name ="[controller].getUser")]
        [AllowAnonymous]
        public async Task<IActionResult> GetUser()
        {
            try
            {
                var jwt = Request.Cookies[ConfigVar.TokenCookie];
                var token = _jwtService.VerifyToken(jwt);
                int userId = int.Parse(token.Issuer);

                var userSession = await _userSessionService.GetUserSessionByUserId(userId);

                var response = new ModelResponse<UserSessionResponse>
                {
                    Data = userSession
                };

                return Ok(response);
            }
            catch
            {
                var errorResponse = new ModelResponse<UserSessionResponse>
                {
                    ErrorResponse = ErrorResponses.UnauthorizedErrorResponse
                };
                return Unauthorized(errorResponse);
            }
        }


        [HttpGet("logout", Name = "[controller].logout")]
        public async Task<IActionResult> Logout()
        {
            Response.Cookies.Delete(ConfigVar.TokenCookie);
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect("/");
        }

        [AllowAnonymous]
        [HttpGet("denied", Name = "[controller].Denied")]
        public async Task<IActionResult> Denied(string ReturnUrl= "/")
        {
            var errorResponse = await Task.Run(() => new ModelResponse<UserSessionResponse>
            {
                ErrorResponse = ErrorResponses.UnauthorizedErrorResponse
            });

            return Unauthorized(errorResponse);
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
