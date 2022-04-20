using JGL.Security.Auth.Data.Responses;
using JGL.Security.Auth.Data.Requests;

namespace JGL.Security.Auth.Domain.Interfaces
{
    interface IUserAccountService
    {
        Task<UserResponse> CreateAccountAsync(CreateUserRequest createUser);
        Task<UserResponse> UpdateAccountAsync(UpdateUserRequest updateUser);
        //public string UpdatePassword(string password);
        //public string ForgotPassword();
    }
}
