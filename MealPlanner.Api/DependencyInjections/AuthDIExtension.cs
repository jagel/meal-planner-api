using MealPlanner.Domain.Auth.Interfaces;
using MealPlanner.Domain.Auth.Services;
using MealPlanner.Infrastructure.DataProvider.Repositories;

namespace MealPlanner.Api.DependencyInjections
{
    public static class AuthDIExtension
    {
        public static void AddAuthenticationSevices(this IServiceCollection service)
        {
            service.AddScoped<IOrganizationRepository, OrganizationRepository>();
            service.AddScoped<IOrganizationService, OrganizationService>();
            service.AddScoped<IOrganizationUserRepository, OrganizationUserRepository>();
            service.AddScoped<ISecurityService, SecurityService>();
            service.AddScoped<IUserRepository, UserRepository>();
            service.AddScoped<IUserService, UserService>();
            service.AddScoped<IUserSessionService, UserSessionService>();
        }
    }
}
