
using JGL.Recipes.Domain.Entities;

namespace JGL.Recipes.Domain.Interfaces
{
    public interface IRecipeRepository
    {
        public Task<Recipe> Create(Recipe recipeCreate);

        public Task<Recipe> Update(Recipe recipeUpdate);

        public Task<Recipe> GetById(int RecipeId);


        public Task<bool> Delete(Recipe recipeDelete);
    }
}
