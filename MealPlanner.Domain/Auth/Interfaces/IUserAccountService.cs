using MealPlanner.Data.Auth;

namespace MealPlanner.Domain.Auth.Interfaces
{
    interface IUserAccountService
    {
        Task<UserResponse> CreateAccountAsync(CreateUserRequest createUser);
        Task<UserResponse> UpdateAccountAsync(UpdateUserRequest updateUser);
        //public string UpdatePassword(string password);
        //public string ForgotPassword();
    }
}
