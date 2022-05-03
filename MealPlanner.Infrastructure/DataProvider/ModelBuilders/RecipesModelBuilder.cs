using JGL.Infra.Globals.DbSettings.Definitions;
using JGL.Infra.Globals.DbSettings.ModelBuilders;
using JGL.Recipes.Domain.Entities;

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

                recipe.HasMany(x => x.RecipeProducts).WithOne().HasForeignKey(x => x.RecipeId);
            });
        }
    }
}
