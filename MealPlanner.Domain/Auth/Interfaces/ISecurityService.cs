using MealPlanner.Domain.Entities.Auth;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace MealPlanner.Domain.Auth.Interfaces
{
    public interface ISecurityService
    {
        bool IsPasswordHashValid(string password, byte[] passwordHash, byte[] passwordSalt);

        (byte[] passwordHash, byte[] passwordSalt) CreatePasswordHash(string password);

        SigningCredentials GetSignInCredentials();
    }
}
