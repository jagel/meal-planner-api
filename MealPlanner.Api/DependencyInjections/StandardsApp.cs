using JGL.Recipes.Domain.Mapper;
using JGL.Domain.Infra.Localizations;
using JGL.Domain.Infra.Profile;
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
            
            services.AddScoped<IUserProfile, UserProfile>();
            services.AddScoped<ILocalization, Localization>();
            services.AddSingleton<IErrorResponseService, ErrorResponseService>();
        }
    }
}
