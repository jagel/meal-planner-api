using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace JGL.Domain.Infra.Profile
{
    public class UserProfile : IUserProfile
    {
        private readonly IHttpContextAccessor _context;

        public UserProfile(IHttpContextAccessor context)
        {
            _context = context;
        }

        public string GetUserEmail()
        {
            var claimEmail = _context.HttpContext.User.Claims
                .FirstOrDefault(x => x.Type == ClaimTypes.Email);
            var email = claimEmail.Value;
            return email;
        }
    }
}
