
using JGL.Recipes.Domain.Entities;
using JGL.Domain.Entities.Recipes.Filters;

namespace JGL.Recipes.Domain.Interfaces
{
    public interface IRecipeRepository
    {
        public Task<Recipe> CreateAsync(Recipe recipeCreate);

        public Task<Recipe> UpdateAsync(Recipe recipeUpdate);

        public Task<Recipe> GetByIdAsync(int RecipeId);

        public Task<IEnumerable<Recipe>> GetByParamsAsync(RecipeFilters recipeFilters);

        public Task<bool> DeleteAsync(Recipe recipeDelete);
    }
}
