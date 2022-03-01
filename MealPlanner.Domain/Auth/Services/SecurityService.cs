using MealPlanner.Domain.Auth.Interfaces;
using MealPlanner.Domain.Entities.Auth;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace MealPlanner.Domain.Auth.Services
{
    public class SecurityService : ISecurityService
    {
        private readonly IConfiguration _configuration;

        public SecurityService(IConfiguration configuration)
        {
            _configuration = configuration;
        }



        public IEnumerable<Claim> GetUserClaims(User user)
        {
            List<Claim> claims = new()
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim("Name", user.Name),
                new Claim("Username", user.Username),
                new Claim("Roles", "Test:Role"),
            };

            return claims;
        }

        public (byte[] passwordHash, byte[] passwordSalt) CreatePasswordHash(string password)
        {
            byte[] passwordSalt;
            byte[] passwordHash;

            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }

            return (passwordHash, passwordSalt);
        }

        public SigningCredentials GetSignInCredentials()
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                _configuration.GetValue<string>("privateTokenKey")
                ));

            var credential = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            return credential;
        }

        public bool IsPasswordHashValid(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            var isValid = false;
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                isValid = computedHash.SequenceEqual(passwordHash);
            }
            return isValid; 
        }
    }
}
