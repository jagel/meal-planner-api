using MealPlanner.Data.Auth.Claims;
using MealPlanner.Domain.Auth.Interfaces;
using MealPlanner.Domain.Auth.Services;
using MealPlanner.Infrastructure.DataProvider.Repositories;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace MealPlanner.Api.DependencyInjections
{
    public static class AuthDIExtension
    {
        public static void AddAuthenticationConfiguration(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(options =>
            {
                options.LoginPath = "/api/auth/denied";
            })
            .AddGoogle(options =>
            {
                options.SignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.ClientId = configuration.GetValue<string>(ConfigVar.Google.ClientId);
                options.ClientSecret = configuration.GetValue<string>(ConfigVar.Google.ClientSecret);
            });
        }

        public static void AddAuthenticationConfigurationv2(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                //options.DefaultChallengeScheme = GoogleDefaults.AuthenticationScheme;
            })
            .AddCookie()
            .AddGoogle(options =>
            {
                options.SignInScheme = GoogleDefaults.AuthenticationScheme;
                options.ClientId = configuration.GetValue<string>(ConfigVar.Google.ClientId);
                options.ClientSecret = configuration.GetValue<string>(ConfigVar.Google.ClientSecret);
            });
        }


        public static void AddAuthenticationDI(this IServiceCollection service)
        {

            //service.AddTransient<IUserClaimsPrincipalFactory<ApplicationUser>, AuthUserClaimsPrincipalFactory>();
            service.AddScoped<IExternalAuthorization, ExternalAuthorization>();
            service.AddScoped<ISecurityService, SecurityService>();
            service.AddScoped<IUserSessionService, UserSessionService>();

            service.AddScoped<IUserService, UserService>();
            service.AddScoped<IOrganizationService, OrganizationService>();

            service.AddScoped<IUserRepository, UserRepository>();
            service.AddScoped<IOrganizationUserRepository, OrganizationUserRepository>();
            service.AddScoped<IOrganizationRepository, OrganizationRepository>();
        }

        
    }
}
