using MealPlanner.Domain.Infra.Localizations;
using MealPlanner.Domain.Infra.Profile;
using MealPlanner.Domain.Mapper;
using NSwag.Generation.AspNetCore;

namespace MealPlanner.Api.DependencyInjections
{
    internal static class StandardsApp
    {
        
        public static void AddStandardServicesApp(this IServiceCollection service)
        {
            service.AddAutoMapper(typeof(MappingProfile));
            service.AddScoped<IUserProfile, UserProfile>();
            service.AddScoped<ILocalization, Localization>();
        }
    }
}
