using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealPlanner.Domain.Entities.Auth
{
    public class Organization
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string OrganizationCode { get; set; }
        public int UserOwnerId { get; set; }

        public virtual IEnumerable<OrganizationUser>? OrganizationUsers { get; set; }

    }
}
