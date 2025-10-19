using JGL.Security.Auth.Domain.Interfaces;
using JGL.Security.Auth.Domain.Entities;
using JGL.Security.Auth.Data.Requests;
using JGL.Security.Auth.Data.Responses;

namespace JGL.Security.Auth.Domain.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ISecurityService _securityService;
        private readonly IUserSessionValidationService _userSessionValidationService;

        public UserService(IUserRepository userRepository,
                           ISecurityService securityService,
                           IUserSessionValidationService userSessionValidationService)
        {
            _userRepository = userRepository;
            _securityService = securityService;
            _userSessionValidationService = userSessionValidationService;
        }

        public async Task<UserResponse> CreateUserAsync(CreateUserRequest createUser)
        {
            await _userSessionValidationService.ValdateUniqueEmailAsync(createUser.Email);

            var user = new User
            {
                Email = createUser.Email,
                Username = createUser.Username,
                Name = createUser.Name,
                Lastname = createUser.Lastname,
                Language = createUser.Language
            };

            var (passworHash, passwordSalt) = _securityService.CreatePasswordHash(createUser.Password);

            user.PasswordHash = passworHash;
            user.PasswordSalt = passwordSalt;

            var userSaved = await _userRepository.CreateUserAsync(user);
            var response = new UserResponse
            {
                UserId = user.Id,
                Email = userSaved.Email,
                Username = userSaved.Username,
                Name = userSaved.Name,
                Lastname = userSaved.Lastname
            };

            return response;
        }

        public async Task<UserSessionResponse> GetUserSessionByIdAsync(int userId)
        {
            var user = await _userRepository.GetUserByIdAsync(userId);

            var userSessionResponse = new UserSessionResponse
            {
                DisplayName = user.Username,
                Email = user.Email,
                Language = user.Language
            };

            return userSessionResponse;
        }

        public async Task<UserResponse> UpdateUserAsync(CreateUserRequest updateUser)
        {
            var updateUserDb = new User
            {
                Email = updateUser.Email,
                Username = updateUser.Username,
                Name = updateUser.Name,
                Lastname = updateUser.Lastname,
                Language = updateUser.Language
            };

            var response = await _userRepository.UpdateUserAsync(updateUserDb);

            var userResponse = new UserResponse
            {
                UserId = response.Id,
                Email = response.Email,
                Username = response.Username,
                Name = response.Name,
                Lastname = response.Lastname
            };

            return userResponse;
        }
    }
}
