using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealPlanner.Domain.Entities.Planners
{
    public class Planner
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string SourceCode { get; set; }
    }
}
