using MealPlanner.Domain.Auth.Interfaces;
using Microsoft.AspNetCore.Authentication;

namespace MealPlanner.Domain.Auth.Services
{
    public class ExternalAuthorization : IExternalAuthorization
    {
        public AuthenticationProperties GenerateAuthenticationProperties(string returnUrl, string urlAPICallback)
        {
            var props = new AuthenticationProperties()
            {
                RedirectUri = urlAPICallback,
                Items =
                {
                    { Definitions.ReturnUrl, returnUrl }
                }
            };
            return props;
        }
    }
}
