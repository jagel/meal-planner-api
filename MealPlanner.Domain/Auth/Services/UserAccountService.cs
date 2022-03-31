using AutoMapper;
using MealPlanner.Data.Auth;
using MealPlanner.Domain.Auth.Interfaces;
using MealPlanner.Domain.Entities.Auth;

namespace MealPlanner.Domain.Auth.Services
{
    public class UserAccountService : IUserAccountService
    {
        private readonly IMapper _mapper;
        private readonly IOrganizationService _organizationService;
        private readonly IOrganizationUserRepository _organizationUserRepository;
        private readonly ISecurityService _securityService;
        private readonly IUserService _userService;

        public UserAccountService(IOrganizationService organizationService,
                           IOrganizationUserRepository organizationUserRepository,
                           ISecurityService securityService,
                           IMapper mapper, 
                           IUserService userService)
        {
            _organizationService = organizationService;
            _organizationUserRepository = organizationUserRepository;
            _securityService = securityService;
            _mapper = mapper;
            _userService = userService;
        }

        public async Task<UserResponse> CreateAccountAsync(CreateUserRequest createUser)
        {
            var user = await _userService.CreateUserAsync(createUser);

            var code = $"{user.Email.Split('@').FirstOrDefault()}_{user.UserId}";
            var organization = await _organizationService.CreateOrganizationAsync(code, user.UserId);

            var organizationUser = await _organizationUserRepository.CreateOrganizationUserAsync(new OrganizationUser { OrganizationId = organization.Id, UserId = user.UserId, UserStatus = EUserStatus.Active });

            var response = _mapper.Map<UserResponse>(user);

            return response;
        }

        public async Task<UserResponse> UpdateAccountAsync(UpdateUserRequest updateUser)
        {
            throw new NotImplementedException();
        }
    }
}
