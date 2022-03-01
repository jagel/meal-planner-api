using MealPlanner.Domain.Entities.Auth;

namespace MealPlanner.Domain.Auth.Interfaces
{
    public interface IOrganizationRepository
    {
        Task<Organization> CreateOrganizationAsync(Organization newOrganization);
        Task<Organization> UpdateOrganizationAsync(Organization updateOrganization);

        Task<Organization> GetOrganizationByIdAsync(int organizationId);
    }
}
