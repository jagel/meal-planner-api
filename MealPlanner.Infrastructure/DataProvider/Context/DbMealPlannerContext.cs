using Microsoft.EntityFrameworkCore;
using JGL.Recipes.Domain.Entities;
using JGL.Security.Auth.Domain.Entities;
using JGL.Infra.Globals.API.Domain.Interfaces;
using JGL.Security.Auth.Infrastructure.DataProvider.ModelBuilder;
using JGL.Infra.Globals.DbSettings.Extensions;
using JGL.Infra.Globals.DbSettings;

namespace JGL.Infrastructure.DataProvider.Context
{
    public class DbMealPlannerContext : BaseDbContext
    {
        public DbMealPlannerContext(DbContextOptions options, 
            IUserSessionProfile userProfile, 
            ITimeService timeService) : base(options, userProfile, timeService)
        {
        }

        // ------------------ Auth
        public DbSet<Organization> Organization { get; set; }
        public DbSet<OrganizationUser> OrganizationUser { get; set; }
        public DbSet<User> User { get; set; }


        // ------------------ Recipes
        public DbSet<Recipe> Recipe { get; set; }
        public DbSet<RecipeProduct> RecipeProduct { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.BuilAuthEntities();
            modelBuilder.BuildEntities();
        }

    }
}
