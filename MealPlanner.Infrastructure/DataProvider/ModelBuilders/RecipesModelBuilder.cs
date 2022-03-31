using JGL.Recipes.Domain.Entities;
using MealPlanner.Infrastructure.DbSettings.Definitions;
using MealPlanner.Infrastructure.DbSettings.ModelBuilders;

namespace JGL.Recipes.Infrastructure.DataProvider.ModelBuilders
{
    public class RecipesModelBuilder : DescriptiveEntityBuilder<Recipe>
    {
        public override void BuildEntity(Microsoft.EntityFrameworkCore.ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Recipe>(recipe =>
            {
                recipe.Property(x => x.Steps)
                    .IsRequired(false)
                    .HasMaxLength(DatabaseProperties.MySQL.MAXLENGTH);
            });
        }
    }
}
