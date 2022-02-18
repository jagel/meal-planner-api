using MealPlanner.Domain.Entities.Recipes;
using MealPlanner.Domain.Recipes.Interfaces;

namespace MealPlanner.Domain.Recipes.Services
{
    public class RecipeValidation : IRecipeValidation
    {
        public void IsEntityNull(Recipe recipe)
        {
            if (recipe == null)
                throw new ArgumentNullException("Recipe not found");
        }
    }
}
