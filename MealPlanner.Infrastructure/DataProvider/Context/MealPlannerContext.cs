using MealPlanner.Domain.Entities.Globals.Interfaces;
using MealPlanner.Domain.Entities.Recipe;
using MealPlanner.Domain.Infra.Profile;
using MealPlanner.Infrastructure.DbSettings;
using MealPlanner.Infrastructure.DbSettings.Extensions;
using Microsoft.EntityFrameworkCore;

namespace MealPlanner.Infrastructure.DataProvider.Context
{
    public class MealPlannerContext : BaseDbContext
    {
        public MealPlannerContext(DbContextOptions options, IUserProfile userProfile, ILocalization localization) : base(options, userProfile, localization)
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
