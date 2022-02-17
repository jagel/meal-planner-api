using JGL.Infra.Domain.Entities;

namespace MealPlanner.Domain.Entities.Recipe
{
    public class Recipe : DescriptiveEntity
    {
        public string? SourceCode { get; set; }
    }
}