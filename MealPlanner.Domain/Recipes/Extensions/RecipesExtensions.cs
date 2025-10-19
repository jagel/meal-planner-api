using JGL.Recipes.Contracts.Models.Recipes;

namespace JGL.Recipes.Domain.Extensions
{
    public static class RecipesExtensions
    {
        public static string StepsToString(this IEnumerable<RecipeSteps> steps)
        {
            var stepsConcatenated = steps.OrderBy(x => x.Order).Select(x =>
             {
                 var item = x.Description.Replace('|', ' ');
                 return item;
             });

            var stepsString = string.Join('|', stepsConcatenated);
            return stepsString;
        }

        public static IEnumerable<RecipeSteps> StepsToList(this string steps)
        {
            var stepsList = steps.Split('|').Select((step, index) =>
                new RecipeSteps
                {
                    Description = step,
                    Order = (index + 1)
                });

            return [..stepsList];
        }
    }
}
