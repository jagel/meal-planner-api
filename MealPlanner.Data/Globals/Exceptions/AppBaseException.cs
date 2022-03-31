using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealPlanner.Data.Globals.Exceptions
{
    public abstract class AppBaseException : Exception
    {
        public ModelErrorResponse ErrorResponse { get; set; }

        public AppBaseException()
        {

        }
    }
}
