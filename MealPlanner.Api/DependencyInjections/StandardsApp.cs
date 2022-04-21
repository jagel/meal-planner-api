using JGL.Recipes.Domain.Mapper;
using JGL.Infra.Globals.API.Domain.Interfaces;
using JGL.Infra.Globals.API.Domain.Services;
using JGL.Infra.ErrorManager.Domain.Services;
using JGL.Infra.ErrorManager.Domain.Interfaces;

namespace JGL.Api.DependencyInjections
{
    internal static class StandardsApp
    {
        
        public static void AddStandardServicesApp(this IServiceCollection services)
        {
            services.AddHttpContextAccessor();
            services.AddAutoMapper(typeof(RecipeMappingProfile));
            services.AddAutoMapper(typeof(Security.Auth.Domain.Mapper.AuthenticationMappingProfile));
            
            services.AddScoped<IUserSessionProfile, UserSessionProfile>();
            services.AddScoped<ITimeService, TimeService>();
            services.AddSingleton<IErrorResponseService, ErrorResponseService>();
        }
    }
}
