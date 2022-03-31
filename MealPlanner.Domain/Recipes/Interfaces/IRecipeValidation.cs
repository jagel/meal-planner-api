using JGL.Recipes.Domain.Entities;

namespace JGL.Recipes.Domain.Interfaces
{
    public interface IRecipeValidation
    {
        public void RecipeNotNullValidation(Recipe recipe);
    }
}
