using MealPlanner.Data.Definitions;
using MealPlanner.Domain.Entities.Recipes;
using MealPlanner.Domain.Infra.Exceptions;
using MealPlanner.Domain.Recipes.Interfaces;

namespace MealPlanner.Domain.Recipes.Services
{
    public class RecipeValidation : IRecipeValidation
    {
        public void RecipeNotNullValidation(Recipe recipe)
        {
            if (recipe == null)
            {
                throw new NotFoundException(
                    new Dictionary<string, string> { { "Not found", "Recipe" } },
                    CodeResponse.NOTFOUND_MESSAGE);
            }
        }
    }
}
