using JGL.Infra.Domain.Entities;

namespace JGL.Recipes.Domain.Entities
{
    public class Recipe : DescriptiveEntity
    {
        public string Steps { get; set; }
    }
}