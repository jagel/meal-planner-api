using JGL.Security.Auth.Domain.Entities;

namespace JGL.Security.Auth.Domain.Interfaces
{
    public interface IOrganizationRepository
    {
        Task<Organization> CreateOrganizationAsync(Organization newOrganization);
        Task<Organization> UpdateOrganizationAsync(Organization updateOrganization);
        Task<Organization> GetOrganizationByIdAsync(int organizationId);
    }
}
