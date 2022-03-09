using MealPlanner.Domain.Entities.Auth;

namespace MealPlanner.Domain.Auth.Interfaces
{
    public interface IOrganizationUserRepository
    {
        Task<OrganizationUser> CreateOrganizationUserAsync(OrganizationUser createOrganizationUser);
        Task<OrganizationUser> UpdateOrganizationUserAsync(OrganizationUser updateOrganizationUser);

        Task<OrganizationUser> GetOrganizationUserByIdAsync(int organizationUserId);
    }
}
