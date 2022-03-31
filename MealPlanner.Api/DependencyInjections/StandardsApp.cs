using MealPlanner.Domain.Infra.Localizations;
using MealPlanner.Domain.Infra.Profile;
using MealPlanner.Domain.Mapper;
using NSwag.Generation.AspNetCore;

namespace MealPlanner.Api.DependencyInjections
{
    internal static class StandardsApp
    {
        
        public static void AddStandardServicesApp(this IServiceCollection services)
        {
            services.AddHttpContextAccessor();
            services.AddAutoMapper(typeof(MappingProfile));
            services.AddScoped<IUserProfile, UserProfile>();
            services.AddScoped<ILocalization, Localization>();
        }
    }
}
