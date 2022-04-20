using System.IdentityModel.Tokens.Jwt;
using JGL.Security.Auth.Domain.Entities;

namespace JGL.Security.Auth.Domain.Interfaces
{
    public interface IJwtService
    {
        string GenerateToken(User uer);
        JwtSecurityToken VerifyToken(string jwt);
    }
}
