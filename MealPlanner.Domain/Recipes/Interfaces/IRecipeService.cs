using JGL.Recipes.Contracts.Models.Recipes;

namespace JGL.Recipes.Domain.Interfaces
{
    public interface IRecipeService
    {
        public Task<Recipe> Create(RecipeCreate recipeCreate);
        public Task<Recipe> Update(RecipeUpdate recipeUpdate);

        public Task<Recipe> GetById(int recipeId);


        public Task<bool> Delete(int recipeId);
    }
}
