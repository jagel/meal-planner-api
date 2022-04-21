using JGL.Infra.Globals.Domain.Entities;

namespace JGL.Recipes.Domain.Entities
{
    public class RecipeProduct: IdentifierEntity
    {
        public string Name { get; set; }
        public int Amount { get; set; }
        public string Fractionary { get; set; }
        public string MeasureType { get; set; }

        public int RecipeId { get; set; }
    }
}
