using MealPlanner.Data.Definitions;
using MealPlanner.Data.Globals;

namespace MealPlanner.Domain.Infra.Interfaces
{
    public interface IMessageResponseService
    {
        ModelErrorResponse CreateErrorResponse(eMessageCollection messageCode);
        ModelErrorResponse AppendErrorResponse(ModelErrorResponse errorMessage, eMessageCollection messageCode);
    }
}
