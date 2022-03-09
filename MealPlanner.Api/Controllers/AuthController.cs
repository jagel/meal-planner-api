using MealPlanner.Data.Auth;
using MealPlanner.Data.Auth.Claims;
using MealPlanner.Domain.Auth.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
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
        private readonly IUserSessionService _userSessionService;
        private readonly ILogger<AuthController> _logger;
        private readonly IConfiguration _configuration;
        private readonly IExternalAuthorization _externalAuthorization;

        public AuthController(IUserSessionService userSessionService,
                              ILogger<AuthController> logger,
                              IConfiguration configuration,
                              IExternalAuthorization externalAuthorization)
        {
            _userSessionService = userSessionService;
            _logger = logger;
            _configuration = configuration;
            _externalAuthorization = externalAuthorization;
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
            {
                return BadRequest(ModelState);
            }

            if (!await _userSessionService.AreCredentialValidAsync(userRequest))
            {
                return Unauthorized();
            }

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

        [HttpGet("signin-google", Name = "[controller].LoginWithGoogle")]
        [AllowAnonymous]
        public async Task<IActionResult> LoginWithGoogle(string returnUrl)
        {
            var apiCallback = Url.Action("GoogleLoginCallback");
            var propAuth = _externalAuthorization.GenerateAuthenticationProperties(returnUrl, apiCallback);
            return Challenge(propAuth, GoogleDefaults.AuthenticationScheme);
        }

        [HttpGet("googleLoginCallback", Name = "[controller].GoogleLoginCallback")]
        [AllowAnonymous]
        public async Task<IActionResult> GoogleLoginCallback()
        {
            var result = await HttpContext.AuthenticateAsync(ConfigVar.Google.AuthenticatioinScheme);
            var externalClaims = result.Principal.Claims.ToList();
            var subjectId = externalClaims.Where(x => x.Type == ClaimTypes.NameIdentifier).Select(x => x.Value).FirstOrDefault();

            //set claims 
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email , "examople.com"),
                new Claim(ClaimTypes.NameIdentifier , subjectId)
            };

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);


            //deleted temporary cookie used during google authentication
            await HttpContext.SignOutAsync(ConfigVar.Google.AuthenticatioinScheme);
            await HttpContext.SignInAsync(ConfigVar.Google.AuthenticatioinScheme, principal);

            return LocalRedirect("/");
        }


        /// <summary>
        /// Ends session for user, returns if was able to log out succesfully
        /// </summary>
        /// <returns>True</returns>
        [HttpGet("logout", Name = "[controller].Logout")]
        public async Task<IActionResult> Logout()
        {
       //     var loggedOut = await _userSessionService.LogOutAsync();
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect("/");
        }

      
    }
}
