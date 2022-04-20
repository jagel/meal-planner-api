using AutoMapper;
using JGL.Security.Auth.Domain.Interfaces;
using JGL.Security.Auth.Domain.Entities;
using JGL.Security.Auth.Data.Requests;
using JGL.Security.Auth.Data.Responses;

namespace JGL.Security.Auth.Domain.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly ISecurityService _securityService;
        private readonly IUserSessionValidationService _userSessionValidationService;

        public UserService(IUserRepository userRepository,
                           ISecurityService securityService,
                           IMapper mapper,
                           IUserSessionValidationService userSessionValidationService)
        {
            _userRepository = userRepository;
            _securityService = securityService;
            _mapper = mapper;
            _userSessionValidationService = userSessionValidationService;
        }

        public async Task<UserResponse> CreateUserAsync(CreateUserRequest createUser)
        {
            await _userSessionValidationService.ValdateUniqueEmailAsync(createUser.Email);

            var user = _mapper.Map<User>(createUser);

            var (passworHash, passwordSalt) = _securityService.CreatePasswordHash(createUser.Password);

            user.PasswordHash = passworHash;
            user.PasswordSalt = passwordSalt;

            var userSaved = await _userRepository.CreateUserAsync(user);
            var response = _mapper.Map<UserResponse>(userSaved);

            return response;
        }

        public async Task<UserSessionResponse> GetUserSessionByIdAsync(int userId)
        {
            var user = await _userRepository.GetUserByIdAsync(userId);

            var userSessionResponse = _mapper.Map<UserSessionResponse>(user);

            return userSessionResponse;
        }

        public async Task<UserResponse> UpdateUserAsync(CreateUserRequest updateUser)
        {
            var updateUserDb = _mapper.Map<User>(updateUser);

            var response = await _userRepository.UpdateUserAsync(updateUserDb);

            var userResponse = _mapper.Map<UserResponse>(response);

            return userResponse;
        }
    }
}
