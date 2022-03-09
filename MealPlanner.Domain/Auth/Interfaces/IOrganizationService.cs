using MealPlanner.Domain.Entities.Auth;

namespace MealPlanner.Domain.Auth.Interfaces
{
    public interface IOrganizationService
    {
        Task<Organization> CreateOrganizationAsync(string code, int userId);
    }
}
