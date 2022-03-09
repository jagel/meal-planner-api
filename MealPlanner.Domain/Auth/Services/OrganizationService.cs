using MealPlanner.Domain.Auth.Interfaces;
using MealPlanner.Domain.Entities.Auth;

namespace MealPlanner.Domain.Auth.Services
{
    public class OrganizationService : IOrganizationService
    {
        private readonly IOrganizationRepository _organizationRepository;

        public OrganizationService(IOrganizationRepository organizationRepository)
        {
            _organizationRepository = organizationRepository;
        }

        public async Task<Organization> CreateOrganizationAsync(string code, int userId)
        {
            var organization = new Organization
            {
                Name = code,
                OrganizationCode = code,
                UserOwnerId = userId,
            };

            var response = await _organizationRepository.CreateOrganizationAsync(organization);

            return response;
        }
    }
}
