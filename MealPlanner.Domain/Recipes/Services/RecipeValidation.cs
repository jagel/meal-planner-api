using JGL.Recipes.Domain.Entities;
using JGL.Recipes.Domain.Interfaces;
using MealPlanner.Data.Definitions;
using MealPlanner.Domain.Infra.Exceptions;

namespace JGL.Recipes.Domain.Validations
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
