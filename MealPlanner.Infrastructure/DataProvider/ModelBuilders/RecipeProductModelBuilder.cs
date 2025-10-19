using JGL.Infra.Globals.DbSettings.Definitions;
using JGL.Infra.Globals.DbSettings.ModelBuilders;
using JGL.Recipes.Domain.Entities;

namespace JGL.Recipes.Infrastructure.DataProvider.ModelBuilders
{
    public class RecipeProductModelBuilder : IdentifierEntityBuilder<RecipeProduct>
    {
        public override void BuildEntity(Microsoft.EntityFrameworkCore.ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RecipeProduct>(recipeProduct =>
            {
                recipeProduct.Property(x=>x.Name)
                   .IsRequired()
                   .HasMaxLength(DatabaseProperties.MySQL.MAXLENGTH_NAME);

                recipeProduct.Property(x => x.Quantity)
                  .IsRequired();

                recipeProduct.Property(x => x.Fractionary)
                   .HasMaxLength(DatabaseProperties.MySQL.MAXLENGTH_FRACTIONARY);

                recipeProduct.Property(x => x.MeasureType)
                  .HasMaxLength(DatabaseProperties.MySQL.MAXLENGTH_NAME);
            });
        }
    }
}
