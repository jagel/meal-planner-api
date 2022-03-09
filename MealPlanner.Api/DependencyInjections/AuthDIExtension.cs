using MealPlanner.Data.Auth.Claims;
using MealPlanner.Domain.Auth.Interfaces;
using MealPlanner.Domain.Auth.Services;
using MealPlanner.Infrastructure.DataProvider.Repositories;
using Microsoft.AspNetCore.Identity;

namespace MealPlanner.Api.DependencyInjections
{
    public static class AuthDIExtension
    {
        public static void AddAuthenticationSevices(this IServiceCollection service)
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
