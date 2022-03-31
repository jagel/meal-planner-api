using MealPlanner.Data.Globals;
using MealPlanner.Data.Globals.Exceptions;

namespace MealPlanner.Domain.Infra.Exceptions
{
    public class DuplicatedException: AppBaseException
    {
        public DuplicatedException(Dictionary<string, string> messageResponse,string title) : base()
        {
            base.ErrorResponse = new()
            {
                Description = title,
                Messages = messageResponse
            };
        }

    
    }
}
