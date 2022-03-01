using MealPlanner.Data.Auth;

namespace MealPlanner.Domain.Auth.Interfaces
{
    public interface IUserSessionService
    {
        Task<bool> AreCredentialValidAsync(UserLoginRequest user);

        Task<string> LogInAsync(UserLoginRequest user);

        Task<bool> LogOutAsync();
    }
}
