using MealPlanner.Domain.Entities.Recipes;

namespace MealPlanner.Domain.Recipes.Interfaces
{
    public interface IRecipeValidation
    {
        public void RecipeNotNullValidation(Recipe recipe);
    }
}
