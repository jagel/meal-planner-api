using JGL.Recipes.Domain.Mapper;
using MealPlanner.Domain.Infra.Localizations;
using MealPlanner.Domain.Infra.Profile;

namespace MealPlanner.Api.DependencyInjections
{
    internal static class StandardsApp
    {
        
        public static void AddStandardServicesApp(this IServiceCollection services)
        {
            services.AddHttpContextAccessor();
            services.AddAutoMapper(typeof(RecipeMappingProfile));
            services.AddAutoMapper(typeof(MealPlanner.Domain.Mapper.AuthenticationMappingProfile));
            
            services.AddScoped<IUserProfile, UserProfile>();
            services.AddScoped<ILocalization, Localization>();
        }
    }
}
