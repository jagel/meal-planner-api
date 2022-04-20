using JGL.Infrastructure.DataProvider.Context;
using JGL.Security.Auth.Domain.Interfaces;
using JGL.Security.Auth.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace JGL.Security.Auth.Infrastructure.DataProvider.Repositories
{
    public class OrganizationUserRepository : IOrganizationUserRepository
    {
        private readonly DbMealPlannerContext _context;

        public OrganizationUserRepository(DbMealPlannerContext context)
        {
            _context = context;
        }

        public async Task<OrganizationUser> CreateOrganizationUserAsync(OrganizationUser createOrganizationUser)
        {
            var entityResponse = _context.Set<OrganizationUser>().Add(createOrganizationUser);

            var savedCount = await _context.SaveChangesAsync();

            return entityResponse?.Entity ?? new OrganizationUser();
        }

        public async Task<OrganizationUser> GetOrganizationUserByIdAsync(int organizationUserId)
        {
            var organizationUser = await _context.Set<OrganizationUser>()
               .Where(x => x.Id == organizationUserId)
               .AsNoTracking()
               .FirstOrDefaultAsync();

            return organizationUser;
        }

        public async Task<OrganizationUser> UpdateOrganizationUserAsync(OrganizationUser updateOrganizationUser)
        {
            var entityResponse = _context.Set<OrganizationUser>().Update(updateOrganizationUser);

            var savedCount = await _context.SaveChangesAsync();

            return entityResponse?.Entity ?? new OrganizationUser(); 
        }
    }
}
