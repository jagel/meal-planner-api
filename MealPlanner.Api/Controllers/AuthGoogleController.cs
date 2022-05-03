using JGL.Globals.Api.Controllers;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using JGL.Security.Auth.Data.Requests;
using JGL.Security.Auth.Domain.Interfaces;
using Microsoft.AspNetCore.Authentication.Google;
using System.Security.Claims;

namespace JGL.Api.Controllers
{
    /// <summary>
    /// Authentication controller
    /// Responisble for validate access to system and logout
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AuthGoogleController : AuthBaseController
    {
        private readonly ILogger<AuthController> _logger;
        private readonly IAuthService _authService;

        public AuthGoogleController(ILogger<AuthController> logger,
            IAuthService authService)
        {
            _logger = logger;
            _authService = authService;
        }

        /// <summary>
        /// Login user google authentication, don't use swagger, requesst by route
        /// </summary>
        /// <param name="returnUrl">Front end Url</param>
        /// <returns>Authentication modal</returns>
        [HttpGet("signin-google", Name = "[controller].LoginWithGoogle")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(string returnUrl)
        {
            var apiCallback = Url.Action("GoogleLoginCallback");
            var propAuth = new AuthenticationProperties()
            {
                RedirectUri = apiCallback,
                Items = { { "returnUrl", returnUrl }}
            };
            return Challenge(propAuth, GoogleDefaults.AuthenticationScheme);
        }


        /// <summary>
        /// Open callback to access by google
        /// </summary>
        /// <returns>Redirect to url from Google login 3th party</returns>
        [HttpGet("googleLoginCallback", Name = "[controller].GoogleLoginCallback")]
        [AllowAnonymous]
        public async Task<IActionResult> GoogleLoginCallback()
        {

            var result = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            var properties = result.Properties.Items;
            var externalClaims = result.Principal.Claims.ToList();
            var email = externalClaims.Where(x => x.Type == ClaimTypes.Email).Select(x => x.Value).FirstOrDefault();

            var authResponse = await _authService.LoginByEmailAsync(email);
            var authenticated = await GenerateValidCredentialsAsync(authResponse);

            var url = "";
            if (properties.ContainsKey(Domain.Definitions.ReturnUrl))
                url = properties[Domain.Definitions.ReturnUrl];

            return Redirect(url);
        }


    }
}
