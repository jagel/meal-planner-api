using JGL.Recipes.Contracts.Models.Recipes;

namespace JGL.Recipes.Domain.Interfaces
{
    public interface IRecipeSearchService
    {
        public Task<IEnumerable<Recipe>> SearchAsync(RecipeSearch recipeSearchParams);
    }
}
