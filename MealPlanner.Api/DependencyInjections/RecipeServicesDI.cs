using JGL.Recipes.Domain.Services;
using JGL.Recipes.Infrastructure.DataProvider.Repositories;
using JGL.Recipes.Domain.Interfaces;
using JGL.Recipes.Domain.Validations;

namespace JGL.Api.DependencyInjections
{
    public static class RecipeServicesDI
    {
        public static void AddRecipeServices(this IServiceCollection services)
        {
            services.AddTransient<IRecipeValidation, RecipeValidation>();

            services.AddTransient<IRecipeService, RecipeService>();
            services.AddTransient<IRecipeSearchService, RecipeSearchService>();
            
            services.AddTransient<IRecipeRepository, RecipeRepository>();
            services.AddTransient<IRecipeProductRepository, RecipeProductRepository>();

        }
    }
}
