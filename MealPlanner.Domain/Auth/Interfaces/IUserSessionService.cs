using MealPlanner.Data.Auth;
using MealPlanner.Data.Auth.Claims;
using System.Security.Claims;

namespace MealPlanner.Domain.Auth.Interfaces
{
    public interface IUserSessionService
    {
        Task<bool> AreCredentialValidAsync(UserLoginRequest user);

        Task LogInAsync(ApplicationUser applicationUser);

        Task<bool> LogOutAsync();

        string GenerateJwt(IEnumerable<Claim> userClaims);
    }
}
