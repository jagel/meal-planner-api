using MealPlanner.Data.Globals.Exceptions;

namespace MealPlanner.Domain.Infra.Exceptions
{
    public class NotFoundException : AppBaseException
    {
        public NotFoundException(Dictionary<string, string> messageResponse, string title) : base()
        {
            base.ErrorResponse = new()
            {
                Description = title,
                Messages = messageResponse
            };
        }
    }
}
