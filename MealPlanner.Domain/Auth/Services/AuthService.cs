using JGL.Security.Auth.Data.Requests;
using JGL.Security.Auth.Domain.Interfaces;
using JGL.Security.Auth.Data.Responses;
using JGL.Security.Auth.Domain.Extensions;

namespace JGL.Security.Auth.Domain.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserSessionValidationService _userSessionValidation;
        private readonly IJwtService _jwtService;

        public AuthService(IUserRepository userRepository,
                           IUserSessionValidationService userSessionValidation,
                           IJwtService jwtService)
        {
            _userRepository = userRepository;
            _userSessionValidation = userSessionValidation;
            _jwtService = jwtService;
        }

        public async Task<LoginResponse> LoginAsync(UserLoginRequest userLogin)
        {
            var dbUser = await _userRepository.GetUserByEmailAsync(userLogin.Email);

            _userSessionValidation.ValidateEntityUser(dbUser);
            _userSessionValidation.ValidatePassword(userLogin.Password, dbUser);

            var jwt = _jwtService.GenerateToken(dbUser);

            return new()
            {
                ClaimsPrincipal = dbUser.ToClaimsPrincipal(),
                Jwt = jwt
            };
        }

        public async Task LogoutAsync()
        {
            
        }
    }
}
