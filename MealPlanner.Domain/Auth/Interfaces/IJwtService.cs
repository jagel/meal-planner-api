using System.IdentityModel.Tokens.Jwt;

namespace MealPlanner.Domain.Auth.Interfaces
{
    public interface IJwtService
    {
        string GenerateToken(int id);

        JwtSecurityToken VerifyToken(string jwt);
    }
}
