using RecipesEntities = MealPlanner.Domain.Entities.Recipes;

namespace MealPlanner.Domain.Recipes.Interfaces
{
    public interface IRecipeRepository
    {
        public Task<RecipesEntities.Recipe> Create(RecipesEntities.Recipe recipeCreate);

        public Task<RecipesEntities.Recipe> Update(RecipesEntities.Recipe recipeUpdate);

        public Task<RecipesEntities.Recipe> GetById(int RecipeId);


        public Task<bool> Delete(RecipesEntities.Recipe recipeDelete);
    }
}
