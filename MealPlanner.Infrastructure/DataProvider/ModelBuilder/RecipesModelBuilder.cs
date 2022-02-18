using MealPlanner.Domain.Entities.Recipes;
using MealPlanner.Infrastructure.DbSettings.Definitions;
using MealPlanner.Infrastructure.DbSettings.ModelBuilders;

namespace MealPlanner.Infrastructure.DataProvider.ModelBuilder
{
    public class RecipesModelBuilder : DescriptiveEntityBuilder<Recipe>
    {
        public override void BuildEntity(Microsoft.EntityFrameworkCore.ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Recipe>(entity =>
            {
               
            });
        }
    }
}
