using JGL.Security.Auth.Data.Responses;
using JGL.Security.Auth.Data.Requests;

namespace JGL.Security.Auth.Domain.Interfaces
{
    public interface IUserService
    {
        Task<UserResponse> CreateUserAsync(CreateUserRequest createUser);

        Task<UserResponse> UpdateUserAsync(CreateUserRequest updateUser);

        Task<UserSessionResponse> GetUserSessionByIdAsync(int userId);
    }
}
