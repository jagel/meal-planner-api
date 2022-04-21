using JGL.Infra.Globals.Domain.Entities;

namespace JGL.Recipes.Domain.Entities
{
    public class Recipe : DescriptiveEntity
    {
        public string Steps { get; set; }

        public IEnumerable<RecipeProduct> RecipeProducts { get; set; }
    }
}