using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealPlanner.Data.Auth.Claims
{
    public class GoogleClaims
    {
        public string Scheme { get; set; }
        public string ReturnUrl { get; set; }
        public string Issued { get; set; }
        public string Expires { get; set; }
        public string Id { get; set; }
    }
}
