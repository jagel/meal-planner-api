using JGL.Recipes.Contracts.Models.Recipes;

namespace JGL.Recipe.Domain.Extensions
{
    public static class RecipesExtensions
    {
        public static string ToString(this IEnumerable<RecipeSteps> recipeSteps)
        {
            var stepsConcatenated = recipeSteps.OrderBy(x => x.Order).Select(x =>
             {
                 var item = x.Description.Replace('|', ' ');
                 return item;
             });

            var stepsString = string.Join('|', stepsConcatenated);
            return stepsString;
        }
    }
}
