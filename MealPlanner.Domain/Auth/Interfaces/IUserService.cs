using MealPlanner.Data.Auth;

namespace MealPlanner.Domain.Auth.Interfaces
{
    public interface IUserService
    {
        Task<UserResponse> CreateUserAsync(CreateUserRequest createUser);

        Task<UserResponse> UpdateUserAsync(CreateUserRequest updateUser);

        Task<UserResponse> GetUserByIdAsync(int userId);

    }
}
