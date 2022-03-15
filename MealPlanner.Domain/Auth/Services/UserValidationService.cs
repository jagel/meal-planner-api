using MealPlanner.Data.Definitions;
using MealPlanner.Domain.Auth.Interfaces;
using MealPlanner.Domain.Infra.Exceptions;

namespace MealPlanner.Domain.Auth.Services
{
    public class UserValidationService : IUserValidationService
    {
        private readonly IUserRepository _userRepository;
        public UserValidationService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task ValdateUniqueEmail(string email)
        {
            var userCreated = await _userRepository.GetUserByEmailAsync(email);
           if (userCreated != null)
            {
                throw new DuplicatedException(                    
                    new Dictionary<string, string> { { "Field duplicated", "Email" } },
                    CodeResponse.DUPLICATED_MESSAGE
                );
            }
        }
    }
}
