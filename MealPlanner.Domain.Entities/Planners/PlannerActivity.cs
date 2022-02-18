using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealPlanner.Domain.Entities.Planners
{
    public class PlannerActivity
    {
        public int Id { get; set; }
        public string SourceCode { get; set; }
        public DateOnly Date { get; set; }

        public int ActivityId { get; set; }

        public int PlannerId { get; set; }
        public Planner? Planner { get; set; }


        public int PlanerRowId { get; set; }

        public Guid UserId { get; set; }
    }
}
