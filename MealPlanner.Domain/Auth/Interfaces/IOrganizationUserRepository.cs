using JGL.Security.Auth.Domain.Entities;

namespace JGL.Security.Auth.Domain.Interfaces
{
    public interface IOrganizationUserRepository
    {
        Task<OrganizationUser> CreateOrganizationUserAsync(OrganizationUser createOrganizationUser);
        Task<OrganizationUser> UpdateOrganizationUserAsync(OrganizationUser updateOrganizationUser);

        Task<OrganizationUser> GetOrganizationUserByIdAsync(int organizationUserId);
    }
}
