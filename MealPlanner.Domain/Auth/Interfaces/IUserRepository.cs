using MealPlanner.Domain.Entities.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealPlanner.Domain.Auth.Interfaces
{
    public interface IUserRepository
    {
        Task<User>
    }
}
