using MealPlanner.Data.Auth.Claims;
using MealPlanner.Domain.Auth.Interfaces;
using MealPlanner.Domain.Auth.Services;
using MealPlanner.Infrastructure.DataProvider.Repositories;
using Microsoft.AspNetCore.Authentication.Cookies;
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
                options.AccessDeniedPath = "/api/auth/denied";
            });
          
        }

        public static void AddAuthenticationDI(this IServiceCollection service)
        {

            //service.AddTransient<IUserClaimsPrincipalFactory<ApplicationUser>, AuthUserClaimsPrincipalFactory>();
            service.AddScoped<IJwtService, JwtService>();


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
