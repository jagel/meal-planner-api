using JGL.Security.Auth.Domain.Entities;

namespace JGL.Security.Auth.Domain.Interfaces
{
    public interface IOrganizationService
    {
        Task<Organization> CreateOrganizationAsync(string code, int userId);
    }
}
