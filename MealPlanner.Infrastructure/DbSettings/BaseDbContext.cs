﻿using MealPlanner.Domain.Entities.Globals.Interfaces;
using MealPlanner.Domain.Infra.Localizations;
using MealPlanner.Domain.Infra.Profile;
using Microsoft.EntityFrameworkCore;


namespace MealPlanner.Infrastructure.DbSettings
{
    public abstract class BaseDbContext : DbContext
    {
        private readonly IUserProfile _userProfile;
        private readonly ILocalization _localization;
        public BaseDbContext(DbContextOptions options, IUserProfile userProfile, ILocalization localization) : base(options)
        {
            _userProfile = userProfile;
            _localization = localization;
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var createEntries = ChangeTracker
                           .Entries()
                           .Where(e => e.Entity is IAuditEntity && e.State == EntityState.Added);

            var updateEntries = ChangeTracker
                            .Entries()
                            .Where(e => e.Entity is IAuditEntity && e.State == EntityState.Modified);

            foreach (var entityEntry in createEntries)
            {
                ((IAuditEntity)entityEntry.Entity).CreatedDate = _localization.GetDateTime();
                ((IAuditEntity)entityEntry.Entity).CreatedBy = _userProfile.GetUserEmail();
            }

            foreach (var entityEntry in updateEntries)
            {
                ((IAuditEntity)entityEntry.Entity).UpdatedDate = _localization.GetDateTime();
                ((IAuditEntity)entityEntry.Entity).UpdatedBy = _userProfile.GetUserEmail();
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        public override int SaveChanges()
        {
            var createEntries = ChangeTracker
                            .Entries()
                            .Where(e => e.Entity is IAuditEntity && e.State == EntityState.Added);

            var updateEntries = ChangeTracker
                            .Entries()
                            .Where(e => e.Entity is IAuditEntity && e.State == EntityState.Modified);

            foreach (var entityEntry in createEntries)
            {
                ((IAuditEntity)entityEntry.Entity).CreatedDate = _localization.GetDateTime();
                ((IAuditEntity)entityEntry.Entity).CreatedBy = _userProfile.GetUserEmail();
            }

            foreach (var entityEntry in updateEntries)
            {
                ((IAuditEntity)entityEntry.Entity).UpdatedDate = _localization.GetDateTime();
                ((IAuditEntity)entityEntry.Entity).UpdatedBy = _userProfile.GetUserEmail();
            }

            return base.SaveChanges();
        }
    }
}