using JGL.Recipes.Domain.Entities;
using MealPlanner.Domain.Entities.Auth;
using MealPlanner.Domain.Infra.Localizations;
using MealPlanner.Domain.Infra.Profile;
using MealPlanner.Infrastructure.DataProvider.ModelBuilder;
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

        // ------------------ Auth
        public DbSet<Organization> Organization { get; set; }
        public DbSet<OrganizationUser> OrganizationUser { get; set; }
        public DbSet<User> User { get; set; }


        // ------------------ Recipes
        public DbSet<Recipe> Recipe { get; set; }


        protected override void OnModelCreating(Microsoft.EntityFrameworkCore.ModelBuilder modelBuilder)
        {
            modelBuilder.BuilAuthdEntities();
            modelBuilder.BuildEntities();
        }

    }
}
