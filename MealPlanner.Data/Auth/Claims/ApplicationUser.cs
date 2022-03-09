using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealPlanner.Data.Auth.Claims
{
    public class ApplicationUser
    {
        public string NameIdentifier { get; set; }
        public string Name { get; set; }
        public string GivenName { get; set; }
        public string Surename { get; set; }
        public string Email { get; set; }
    }
}
