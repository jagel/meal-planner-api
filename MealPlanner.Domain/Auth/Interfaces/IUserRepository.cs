using JGL.Security.Auth.Domain.Entities;

namespace JGL.Security.Auth.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<User> CreateUserAsync(User createUser);
        Task<User> UpdateUserAsync(User updateUser);

        Task<User> GetUserByIdAsync(int userId);
        Task<User> GetUserByEmailAsync(string email);
    }
}
