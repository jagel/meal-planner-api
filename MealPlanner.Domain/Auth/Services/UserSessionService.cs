using MealPlanner.Data.Auth;
using MealPlanner.Data.Auth.Claims;
using MealPlanner.Domain.Auth.Interfaces;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace MealPlanner.Domain.Auth.Services
{
    public class UserSessionService : IUserSessionService
    {
        private readonly IUserRepository _userRepository;
        private readonly ISecurityService _securityService;

        public UserSessionService(IUserRepository userRepository, 
                                  ISecurityService securityService)
        {
            _userRepository = userRepository;
            _securityService = securityService;
        }

        public async Task<bool> AreCredentialValidAsync(UserLoginRequest user)
        {
            var dbUser = await _userRepository.GetUserByEmailAsync(user.Email);
            var userCredentialValid = false;

            if (dbUser != null) 
            {
                userCredentialValid = _securityService.IsPasswordHashValid(user.Password, dbUser.PasswordHash, dbUser.PasswordSalt);
            }
            return userCredentialValid;
        }

        public async Task<ClaimsPrincipal> GetClaimsPrincipalByUserId(int userId)
        {
            var userDb = await _userRepository.GetUserByIdAsync(userId);

            var claimsList = new List<Claim>
            {
                new Claim(ClaimTypes.Email , userDb.Email),
                new Claim(ClaimTypes.NameIdentifier , userId.ToString())
            };

            var mainIdentity = new ClaimsIdentity(claimsList, CookieAuthenticationDefaults.AuthenticationScheme);
            
            var claimsPrincipal = new List<ClaimsIdentity>
            {
                mainIdentity
            };

            var principal = new ClaimsPrincipal(claimsPrincipal);
            return principal;
        }

        public async Task<UserSessionResponse> GetUserSessionByUserId(int userId)
        {
            var dbUser = await _userRepository.GetUserByIdAsync(userId);

            return new UserSessionResponse
            {
                DisplayName = $"{dbUser.Name} {dbUser.Lastname}",
                Email = dbUser.Email,
                Language = "en"
            };
        }

     

      
    }
}
