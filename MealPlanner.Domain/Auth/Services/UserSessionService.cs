using MealPlanner.Data.Auth;
using MealPlanner.Domain.Auth.Interfaces;
using System.IdentityModel.Tokens.Jwt;

namespace MealPlanner.Domain.Auth.Services
{
    public class UserSessionService : IUserSessionService
    {
        private readonly IUserRepository _userRepository;
        private readonly ISecurityService _securityService;

        public UserSessionService(IUserRepository userRepository, ISecurityService securityService)
        {
            _userRepository = userRepository;
            _securityService = securityService;
        }

        public async Task<bool> AreCredentialValidAsync(UserLoginRequest user)
        {
            var dbUser = await _userRepository.GetUserByEmailAsync(user.Email);
            var userCredentialValid = false;

            if (dbUser != null  ) 
            {
                userCredentialValid = _securityService.IsPasswordHashValid(user.Password, dbUser.PasswordHash, dbUser.PasswordSalt);
            }
            return userCredentialValid;
        }

        public async Task<string> LogInAsync(UserLoginRequest user)
        {
            var dbUser = await _userRepository.GetUserByEmailAsync(user.Email);

            var userClaims = _securityService.GetUserClaims(dbUser);

            var signInCredentials = _securityService.GetSignInCredentials();

            var token = new JwtSecurityToken(
                claims: userClaims,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: signInCredentials
             );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }

        public Task<bool> LogOutAsync()
        {
            throw new NotImplementedException();
        }
    }
}
