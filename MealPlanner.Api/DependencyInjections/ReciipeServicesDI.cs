using JGL.Recipes.Domain.Services;
using JGL.Recipes.Infrastructure.DataProvider.Repositories;
using JGL.Recipes.Domain.Interfaces;
using JGL.Recipes.Domain.Validations;

namespace MealPlanner.Api.DependencyInjections
{
    public static class ReciipeServicesDI
    {
        public static void AddRecipeServices(this IServiceCollection services)
        {
            services.AddTransient<IRecipeRepository, RecipeRepository>();
            services.AddTransient<IRecipeService, RecipeService>();
            services.AddTransient<IRecipeValidation, RecipeValidation>();
        }
    }
}
