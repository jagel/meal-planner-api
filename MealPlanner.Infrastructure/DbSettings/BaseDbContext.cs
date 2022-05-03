using JGL.Infra.Globals.API.Domain.Interfaces;
using JGL.Infra.Globals.Domain.Entities.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace JGL.Infra.Globals.DbSettings
{
    public abstract class BaseDbContext : DbContext
    {
        private readonly IUserSessionProfile _userProfile;
        private readonly ITimeService _timeService;
        public BaseDbContext(DbContextOptions options, IUserSessionProfile userProfile, ITimeService timeService) : base(options)
        {
            _userProfile = userProfile;
            _timeService = timeService;
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
                ((IAuditEntity)entityEntry.Entity).CreatedDate = _timeService.GetDateTime();
                ((IAuditEntity)entityEntry.Entity).CreatedBy = _userProfile.GetUserInSession();
            }

            foreach (var entityEntry in updateEntries)
            {
                entityEntry.Property(nameof(IAuditEntity.CreatedBy)).IsModified = false;
                entityEntry.Property(nameof(IAuditEntity.CreatedDate)).IsModified = false;

                ((IAuditEntity)entityEntry.Entity).UpdatedDate = _timeService.GetDateTime();
                ((IAuditEntity)entityEntry.Entity).UpdatedBy = _userProfile.GetUserInSession();
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
                ((IAuditEntity)entityEntry.Entity).CreatedDate = _timeService.GetDateTime();
                ((IAuditEntity)entityEntry.Entity).CreatedBy = _userProfile.GetUserInSession();
            }

            foreach (var entityEntry in updateEntries)
            {
                entityEntry.Property(nameof(IAuditEntity.CreatedBy)).IsModified = false;
                entityEntry.Property(nameof(IAuditEntity.CreatedDate)).IsModified = false;

                ((IAuditEntity)entityEntry.Entity).UpdatedDate = _timeService.GetDateTime();
                ((IAuditEntity)entityEntry.Entity).UpdatedBy = _userProfile.GetUserInSession();
            }

            return base.SaveChanges();
        }
    }
}
