using Microsoft.EntityFrameworkCore;
using JGL.Recipes.Domain.Entities;
using JGL.Security.Auth.Domain.Entities;
using JGL.Domain.Infra.Localizations;
using JGL.Domain.Infra.Profile;
using JGL.Infrastructure.DbSettings;
using JGL.Infrastructure.DbSettings.Extensions;
using JGL.Security.Auth.Infrastructure.DataProvider.ModelBuilder;

namespace JGL.Infrastructure.DataProvider.Context
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
            modelBuilder.BuilAuthEntities();
            modelBuilder.BuildEntities();
        }

    }
}
