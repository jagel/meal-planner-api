
using JGL.Recipes.Domain.Entities;
using JGL.Recipes.Domain.Entities.Filters;

namespace JGL.Recipes.Domain.Interfaces
{
    public interface IRecipeRepository
    {
        public Task<Recipe> CreateAsync(Recipe recipeCreate);

        public Task<Recipe> UpdateAsync(Recipe recipeUpdate);

        public Task<Recipe> GetByIdAsync(int RecipeId, RecipeFilter recipeFilters = null);

        public Task<IEnumerable<Recipe>> GetByParamsAsync(RecipeSearch recipeSearch);

        public Task<bool> DeleteAsync(Recipe recipeDelete);
    }
}
