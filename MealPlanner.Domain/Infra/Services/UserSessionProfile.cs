using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using JGL.Infra.Globals.API.Domain.Interfaces;

namespace JGL.Infra.Globals.API.Domain.Services
{
    public class UserSessionProfile : IUserSessionProfile
    {
        private readonly IHttpContextAccessor _context;

        public UserSessionProfile(IHttpContextAccessor context)
        {
            _context = context;
        }

        public string GetUserEmail()
        {
            var claimEmail = _context.HttpContext.User.Claims
                .FirstOrDefault(x => x.Type == ClaimTypes.Email);
            var email = claimEmail?.Value??"";
            return email;
        }

        public string GetUserInSession()
        {
            var nameIdentifier = _context.HttpContext.User.Claims
              .FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);
            var nameId = nameIdentifier?.Value??"";
            return nameId;
        }
    }
}
