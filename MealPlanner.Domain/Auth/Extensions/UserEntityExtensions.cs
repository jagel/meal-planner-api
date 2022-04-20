using JGL.Security.Auth.Domain.Entities;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;

namespace JGL.Security.Auth.Domain.Extensions
{
    public static class UserEntityExtensions
    {
        public static List<Claim> ToClaimList(this User user)
            => new()
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
            };

        public static ClaimsPrincipal ToClaimsPrincipal(this User user)
        {
            var claimList = user.ToClaimList();

            var mainIdentity = new ClaimsIdentity(claimList, CookieAuthenticationDefaults.AuthenticationScheme);

            var claimsPrincipal = new List<ClaimsIdentity>
            {
                mainIdentity
            };

            var principal = new ClaimsPrincipal(claimsPrincipal);
            return principal;
        }
          
    }
}
