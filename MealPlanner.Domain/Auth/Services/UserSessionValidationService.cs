using JGL.Security.Auth.Domain.Interfaces;
using JGL.Infra.ErrorManager.Domain.Interfaces;
using JGL.Infra.ErrorManager.Domain.Exceptions;

namespace JGL.Security.Auth.Domain.Services
{
    public class UserSessionValidationService : IUserSessionValidationService
    {
        private readonly IUserRepository _userRepository;
        private readonly ISecurityService _securityService;
        private readonly IErrorResponseService _errorResponseService;

        public UserSessionValidationService(IUserRepository userRepository,
            ISecurityService securityService,
            IErrorResponseService errorResponseService)
        {
            _userRepository = userRepository;
            _securityService = securityService;
            _errorResponseService = errorResponseService;
        }

        public async Task ValdateUniqueEmailAsync(string email)
        {
            var userCreated = await _userRepository.GetUserByEmailAsync(email);
            if (userCreated != null)
            {
                var errorResponse = _errorResponseService.Duplicated("Users", "Email", email);
                throw new JGLAppException(errorResponse);
            }
        }

        public void ValidateEntityUser(Entities.User user)
        {
            if (user == null)
            {
                var errorResponse = _errorResponseService.Unauthorized();
                throw new JGLAppException(errorResponse);
            }
        }

        public void ValidatePassword(string requestPassword, Entities.User user)
        {
            if (!_securityService.IsPasswordHashValid(requestPassword, user.PasswordHash, user.PasswordSalt))
            {
                var errorResponse = _errorResponseService.Unauthorized();
                throw new JGLAppException(errorResponse);
            }
        }
    }
}
