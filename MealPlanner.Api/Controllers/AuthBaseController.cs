using JGL.Security.Auth.Data.Responses;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace JGL.Api.Controllers
{
    public abstract class AuthBaseController : ControllerBase
    {
       internal async Task<bool> GenerateValidCredentialsAsync(LoginResponse authResponse, AuthenticationProperties properties = null)
        {
            if (authResponse.Authenticated)
            {
                Response.Cookies.Delete(ConfigVar.TokenCookie);
                await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                
                Response.Cookies.Append(ConfigVar.TokenCookie, authResponse.Jwt, new CookieOptions { HttpOnly = true, });


                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    authResponse.ClaimsPrincipal,
                    properties);
            }
            return authResponse.Authenticated;
        }
    }
}
