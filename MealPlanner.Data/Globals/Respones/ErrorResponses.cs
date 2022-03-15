using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealPlanner.Data.Globals.Respones
{
    public static class ErrorResponses
    {
        public static ModelErrorResponse InternalErrorResponse = new ModelErrorResponse
        {
            Description = "Internal Error",
            Messages = new Dictionary<string, string>
            {
                { "Internal Error", "Request error response" }
            }
        };
    }
}
