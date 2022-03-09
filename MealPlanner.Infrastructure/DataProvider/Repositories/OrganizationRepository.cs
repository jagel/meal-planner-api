﻿using MealPlanner.Domain.Auth.Interfaces;
using MealPlanner.Domain.Entities.Auth;
using MealPlanner.Infrastructure.DataProvider.Context;
using Microsoft.EntityFrameworkCore;

namespace MealPlanner.Infrastructure.DataProvider.Repositories
{
    public class OrganizationRepository : IOrganizationRepository
    {
        private readonly DbMealPlannerContext _context;

        public OrganizationRepository(DbMealPlannerContext context)
        {
            _context = context;
        }

        public async Task<Organization> CreateOrganizationAsync(Organization newOrganization)
        {
            var entityResponse = _context.Set<Organization>().Add(newOrganization);

            var savedCount = await _context.SaveChangesAsync();

            return entityResponse?.Entity ?? new Organization();
        }

        public async Task<Organization> GetOrganizationByIdAsync(int organizationId)
        {
            var organization = await _context.Set<Organization>()
                .Where(x => x.Id == organizationId)
                .AsNoTracking()
                .FirstOrDefaultAsync();

            return organization;
        }

        public async Task<Organization> UpdateOrganizationAsync(Organization updateOrganization)
        {
            var response = _context.Set<Organization>().Update(updateOrganization);

            var updatedCount = await _context.SaveChangesAsync();
            
            return response?.Entity ?? new Organization();
        }
    }
}
