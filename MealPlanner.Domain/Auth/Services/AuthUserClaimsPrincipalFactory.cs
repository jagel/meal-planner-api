using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MealPlanner.Data.Auth.Claims
{
    public class AuthUserClaimsPrincipalFactory : UserClaimsPrincipalFactory<ApplicationUser>
    {
        public AuthUserClaimsPrincipalFactory(
            UserManager<ApplicationUser> userManager, 
            IOptions<IdentityOptions> optionsAccessor) 
                : base(userManager, optionsAccessor)
        {
        }

        protected override async Task<ClaimsIdentity> GenerateClaimsAsync(ApplicationUser user)
        {
            var identity = await base.GenerateClaimsAsync(user);

            identity.AddClaim(new Claim("nameidentifier", user.NameIdentifier));
            identity.AddClaim(new Claim("name", user.Name));
            identity.AddClaim(new Claim("givenname", user.GivenName));
            identity.AddClaim(new Claim("surname", user.Surename));
            identity.AddClaim(new Claim("emailaddress", user.Email));

            return identity;
        }
    }
}
