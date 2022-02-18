using MealPlanner.Domain.Entities.Recipes;
using MealPlanner.Domain.Infra.Localizations;
using MealPlanner.Domain.Infra.Profile;
using MealPlanner.Infrastructure.DbSettings;
using MealPlanner.Infrastructure.DbSettings.Extensions;
using Microsoft.EntityFrameworkCore;

namespace MealPlanner.Infrastructure.DataProvider.Context
{
    public class DbMealPlannerContext : BaseDbContext
    {
        public DbMealPlannerContext(DbContextOptions options, IUserProfile userProfile, ILocalization localization) : base(options, userProfile, localization)
        {
        }
        // ------------------ R
        public DbSet<Recipe> Recipe { get; set; }


        protected override void OnModelCreating(Microsoft.EntityFrameworkCore.ModelBuilder modelBuilder)
        {
            modelBuilder.BuildEntities();
        }

    }
}
