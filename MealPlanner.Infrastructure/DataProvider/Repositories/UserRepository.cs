using MealPlanner.Domain.Auth.Interfaces;
using MealPlanner.Domain.Entities.Auth;
using MealPlanner.Infrastructure.DataProvider.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealPlanner.Infrastructure.DataProvider.Repositories
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
