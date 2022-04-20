using JGL.Security.Auth.Domain.Entities;

namespace JGL.Security.Auth.Domain.Interfaces
{
    public interface IUserSessionValidationService
    {
        void ValidateEntityUser(User user);
        void ValidatePassword(string requestPassword, User user);
        Task ValdateUniqueEmailAsync(string email);
    }
}
