using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealPlanner.Data.Globals.Responses
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

        public static ModelErrorResponse UnauthorizedErrorResponse = new ModelErrorResponse
        {
            Description = "Unauthorize",
        };
    }
}
