using JGL.Security.Auth.Data.Requests;
using JGL.Security.Auth.Data.Responses;

namespace JGL.Security.Auth.Domain.Interfaces
{
    public interface IAuthService
    {
        Task<LoginResponse> LoginAsync(UserLoginRequest userLogin);
        Task LogoutAsync();
    }
}
