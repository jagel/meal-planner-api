using MealPlanner.Domain.Entities.Recipe;
using MealPlanner.Domain.Infra.Definitions;
using MealPlanner.Infrastructure.DbSettings.Definitions;
using MealPlanner.Infrastructure.DbSettings.Extensions;
using MealPlanner.Infrastructure.DbSettings.ModelBuilders;

namespace MealPlanner.Infrastructure.DataProvider.ModelBuilder
{
    public class RecipesModelBuilder : DescriptiveEntityBuilder<Recipe>
    {
        public override void BuildEntity(Microsoft.EntityFrameworkCore.ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Recipe>(entity =>
            {
                entity.Property(x => x.SourceCode)
                    //.HasDefaultValue(E_SOURCE_CODE.Active)
                    .HasConversion(ConvertersExtension.EnumConverter<PlannerSourceCode.E_SOURCE_CODE>())
                    .IsRequired()
                    .HasMaxLength(DatabaseProperties.MySQL.MAXLENGTH_ENUM);

            });
        }
    }
}
