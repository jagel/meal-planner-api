using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealPlanner.Domain.Entities.Auth
{
    public class OrganizationUser
    {
        public int Id { get; set; }
        public string Status { get; set; }

        public int OrganizationId { get; set; }
        public Organization Organization { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}
