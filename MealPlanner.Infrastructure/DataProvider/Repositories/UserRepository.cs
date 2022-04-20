using JGL.Infrastructure.DataProvider.Context;
using JGL.Security.Auth.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using JGL.Security.Auth.Domain.Entities;

namespace JGL.Security.Auth.Infrastructure.DataProvider.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DbMealPlannerContext _context;

        public UserRepository(DbMealPlannerContext context)
        {
            _context = context;
        }

        public async Task<User> CreateUserAsync(User createUser)
        {
            var entityResponse = _context.Set<User>().Add(createUser);

            var savedCount = await _context.SaveChangesAsync();

            return entityResponse?.Entity ?? new User();
        }

        public async Task<User> UpdateUserAsync(User updateUser)
        {
            var entityResponse = _context.Set<User>().Update(updateUser);

            var savedCount = await _context.SaveChangesAsync();

            return entityResponse?.Entity ?? new User();
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            var user = await _context.Set<User>()
             .Where(x => x.Email == email)
             .AsNoTracking()
             .FirstOrDefaultAsync();

            return user;
        }

        public async Task<User> GetUserByIdAsync(int userId)
        {
            var organizationUser = await _context.Set<User>()
             .Where(x => x.Id == userId)
             .AsNoTracking()
             .FirstOrDefaultAsync();

            return organizationUser;
        }
    }
}
