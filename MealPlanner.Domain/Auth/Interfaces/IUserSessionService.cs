using MealPlanner.Data.Auth;
using System.Security.Claims;

namespace MealPlanner.Domain.Auth.Interfaces
{
    public interface IUserSessionService
    {
        Task<bool> AreCredentialValidAsync(UserLoginRequest user);

        Task<UserSessionResponse> GetUserSessionByUserId(int userId);

        Task<ClaimsPrincipal> GetClaimsPrincipalByUserId(int userId);
    }
}
