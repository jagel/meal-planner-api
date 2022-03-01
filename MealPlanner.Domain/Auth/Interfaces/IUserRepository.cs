using MealPlanner.Domain.Entities.Auth;

namespace MealPlanner.Domain.Auth.Interfaces
{
    public interface IUserRepository
    {
        Task<User> CreateUserAsync(User createUser);
        Task<User> UpdateUserAsync(User updateUser);

        Task<User> GetUserByIdAsync(int userId);
        Task<User> GetUserByEmailAsync(string email);
    }
}
