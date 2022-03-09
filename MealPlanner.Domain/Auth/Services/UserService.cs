﻿using AutoMapper;
using MealPlanner.Data.Auth;
using MealPlanner.Domain.Auth.Interfaces;
using MealPlanner.Domain.Entities.Auth;

namespace MealPlanner.Domain.Auth.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly IOrganizationService _organizationService;
        private readonly IOrganizationUserRepository _organizationUserRepository;
        private readonly ISecurityService _securityService;

        public UserService(IUserRepository userRepository,
                           IOrganizationService organizationService,
                           IOrganizationUserRepository organizationUserRepository,
                           ISecurityService securityService, 
                           IMapper mapper)
        {
            _userRepository = userRepository;
            _organizationService = organizationService;
            _organizationUserRepository = organizationUserRepository;
            _securityService = securityService;
            _mapper = mapper;
        }



        public async Task<UserResponse> CreateUserAsync(CreateUserRequest createUser)
        {
            var user = _mapper.Map<User>(createUser);

            var (passworHash, passwordSalt) = _securityService.CreatePasswordHash(createUser.Password);

            user.PasswordHash = passworHash;
            user.PasswordSalt = passwordSalt;

            var userSaved = await _userRepository.CreateUserAsync(user);

            var code = $"{userSaved.Email.Split('@').FirstOrDefault()}_{userSaved.Id}";
            var organization = await _organizationService.CreateOrganizationAsync(code, userSaved.Id);

            var organizationUser = await _organizationUserRepository.CreateOrganizationUserAsync(new OrganizationUser { OrganizationId = organization.Id, UserId = userSaved.Id, UserStatus = EUserStatus.Active});

            var response = _mapper.Map<UserResponse>(userSaved);

            return response;
        }

        public async Task<UserResponse> GetUserByIdAsync(int userId)
        {
            var user = await _userRepository.GetUserByIdAsync(userId);

            var userResponse = _mapper.Map<UserResponse>(user);

            return userResponse;
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
