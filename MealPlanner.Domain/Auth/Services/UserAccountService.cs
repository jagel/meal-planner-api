using JGL.Security.Auth.Domain.Interfaces;
using JGL.Security.Auth.Domain.Entities;
using JGL.Security.Auth.Data.Requests;
using JGL.Security.Auth.Data.Responses;

namespace JGL.Security.Auth.Domain.Services
{
    public class UserAccountService : IUserAccountService
    {
        private readonly IOrganizationService _organizationService;
        private readonly IOrganizationUserRepository _organizationUserRepository;
        private readonly IUserService _userService;

        public UserAccountService(IOrganizationService organizationService,
                           IOrganizationUserRepository organizationUserRepository,
                           IUserService userService)
        {
            _organizationService = organizationService;
            _organizationUserRepository = organizationUserRepository;
            _userService = userService;
        }

        public async Task<UserResponse> CreateAccountAsync(CreateUserRequest createUser)
        {
            var user = await _userService.CreateUserAsync(createUser);

            var code = $"{user.Email.Split('@').FirstOrDefault()}_{user.UserId}";
            var organization = await _organizationService.CreateOrganizationAsync(code, user.UserId);

            var organizationUser = await _organizationUserRepository.CreateOrganizationUserAsync(new OrganizationUser { OrganizationId = organization.Id, UserId = user.UserId, UserStatus = EUserStatus.Active });


            var response = new UserResponse
            {
                Email = user.Email,
                Lastname = user.Lastname,
                Name = user.Name,
                UserId = user.UserId,
                Username = user.Username
            };

            return response;
        }

        public async Task<UserResponse> UpdateAccountAsync(UpdateUserRequest updateUser)
        {
            throw new NotImplementedException();
        }
    }
}
