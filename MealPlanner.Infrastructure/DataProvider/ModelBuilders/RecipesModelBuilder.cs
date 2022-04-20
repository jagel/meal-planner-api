using JGL.Recipes.Domain.Entities;
using JGL.Infrastructure.DbSettings.Definitions;
using JGL.Infrastructure.DbSettings.ModelBuilders;

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
