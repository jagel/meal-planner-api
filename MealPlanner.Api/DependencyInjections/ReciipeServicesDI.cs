using MealPlanner.Domain.Recipes.Interfaces;
using MealPlanner.Domain.Recipes.Services;
using MealPlanner.Infrastructure.DataProvider.Repositories;

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
