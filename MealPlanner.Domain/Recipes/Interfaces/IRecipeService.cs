using JGL.Recipes.Contracts.Models.Recipes;

namespace MealPlanner.Domain.Recipes.Interfaces
{
    public interface IRecipeService
    {
        public Task<Recipe> Create(RecipeCreate recipeCreate);
        public Task<Recipe> Update(RecipeUpdate recipeUpdate);

        public Task<Recipe> GetById(int recipeId);


        public Task<bool> Delete(int recipeId);
    }
}
