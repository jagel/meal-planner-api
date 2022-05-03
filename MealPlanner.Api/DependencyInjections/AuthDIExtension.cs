using JGL.Security.Auth.Domain.Interfaces;
using JGL.Security.Auth.Domain.Services;
using JGL.Security.Auth.Infrastructure.DataProvider.Repositories;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace JGL.Security.Auth.API.DependencyInjections
{
    public static class AuthDIExtension
    {
        public static void AddAuthenticationConfiguration(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(options =>
            {
                options.AccessDeniedPath = "/api/auth/denied";
            })
            .AddGoogle(options =>
            {
                options.SignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.ClientId = configuration.GetValue<string>(ConfigVar.Google.ClientId);
                options.ClientSecret = configuration.GetValue<string>(ConfigVar.Google.ClientSecret);
            });
          
        }

        public static void AddAuthenticationDI(this IServiceCollection service)
        {

            //service.AddTransient<IUserClaimsPrincipalFactory<ApplicationUser>, AuthUserClaimsPrincipalFactory>();
            service.AddScoped<IJwtService, JwtService>();
            service.AddScoped<IAuthService, AuthService>();

            service.AddScoped<ISecurityService, SecurityService>();

            service.AddScoped<IUserService, UserService>();
            service.AddScoped<IOrganizationService, OrganizationService>();

            service.AddScoped<IUserRepository, UserRepository>();
            service.AddScoped<IOrganizationUserRepository, OrganizationUserRepository>();
            service.AddScoped<IOrganizationRepository, OrganizationRepository>();

            service.AddScoped<IUserSessionValidationService, UserSessionValidationService>();
        }


    }
}
